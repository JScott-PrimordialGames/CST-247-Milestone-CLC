﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MinesAPI.DTOs;
using MinesAPI.Models;
using MinesAPI.Service.Business;

namespace MinesAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class GameResultsService : IGameResultsService
    {
        List<GameResultsModel> gameResults;

        private GameResultsService()
        {
            gameResults = new List<GameResultsModel>();
            GameResultsModel model1 = new GameResultsModel();
            model1.UserId = 1;
            model1.UserName = "Donald Trowbridge";
            List<GameScoresModel> scores1 = new List<GameScoresModel>();
            scores1.Add(new GameScoresModel { Difficulty = "Beginner", Score = 9.89f });
            scores1.Add(new GameScoresModel { Difficulty = "Beginner", Score = 11.23f });
            scores1.Add(new GameScoresModel { Difficulty = "Intermediate", Score = 54.34f });
            model1.GameScores = scores1;
            gameResults.Add(model1);

            GameResultsModel model2 = new GameResultsModel();
            model2.UserId = 2;
            model2.UserName = "Brydon Johnson";
            List<GameScoresModel> scores2 = new List<GameScoresModel>();
            scores2.Add(new GameScoresModel { Difficulty = "Beginner", Score = 23.45f });
            scores2.Add(new GameScoresModel { Difficulty = "Beginner", Score = 18.76f });
            scores2.Add(new GameScoresModel { Difficulty = "Intermediate", Score = 76.43f });
            model2.GameScores = scores2;
            gameResults.Add(model2);

            GameResultsModel model3 = new GameResultsModel();
            model3.UserId = 3;
            model3.UserName = "Joshua Scott";
            List<GameScoresModel> scores3 = new List<GameScoresModel>();
            scores3.Add(new GameScoresModel { Difficulty = "Beginner", Score = 27.56f });
            scores3.Add(new GameScoresModel { Difficulty = "Beginner", Score = 20.43f });
            scores3.Add(new GameScoresModel { Difficulty = "Intermediate", Score = 89.99f });
            model3.GameScores = scores3;
            gameResults.Add(model3);
        }
        public GameResultsDTO GetGameResults(string limit = "0")
        {
            int limitInt = 0;
            Int32.TryParse(limit, out limitInt);
            GameResultsBusinessService service = new GameResultsBusinessService();
            List<GameResultsModel> gameResultsList = service.GetGameResults(limitInt);
            GameResultsDTO gameResultsDTO = new GameResultsDTO();
            gameResultsDTO.ErrorCode = 0;
            gameResultsDTO.ErrorMessage = "OK";
            gameResultsDTO.GameResults = gameResultsList;
            return gameResultsDTO;
        }

        public GameResultsDTO GetGameResultsForUser(string id)
        {
            int userId = 0;
            Int32.TryParse(id, out userId);
            if (userId <= 0)
            {
                GameResultsDTO gameResultsDTO = new GameResultsDTO();
                gameResultsDTO.ErrorCode = 400;
                gameResultsDTO.ErrorMessage = "Bad Request: The user id sent is not valid";
                return gameResultsDTO;
            }
            else
            {
                GameResultsBusinessService service = new GameResultsBusinessService();
                if (service.UserExists(userId))
                {
                    GameResultsDTO gameResultsDTO = new GameResultsDTO();
                    gameResultsDTO.ErrorCode = 0;
                    gameResultsDTO.ErrorMessage = "OK";
                    gameResultsDTO.GameResults = service.GetGameResultsByUser(userId);
                    return gameResultsDTO;
                } else
                {
                    GameResultsDTO gameResultsDTO = new GameResultsDTO();
                    gameResultsDTO.ErrorCode = 404;
                    gameResultsDTO.ErrorMessage = "Not Found: There are no resources for the user with id: " + userId.ToString() + ".";
                    return gameResultsDTO;
                }
                    
            }
        }

        public GameResultsDTO GetGameResultsForUserAndGameDifficulty(string id, string difficulty)
        {
            int userId = 0;
            int difficultyLevel = 0;
            Int32.TryParse(id, out userId);
            GameResultsDTO gameResultsDTO;

            if (!difficulty.ToLower().Equals("beginner") && !difficulty.ToLower().Equals("intermediate") && !difficulty.ToLower().Equals("expert")
                     && !difficulty.ToLower().Equals("1") && !difficulty.ToLower().Equals("2") && !difficulty.ToLower().Equals("3"))
            {
                gameResultsDTO = new GameResultsDTO();
                gameResultsDTO.ErrorCode = 400;
                gameResultsDTO.ErrorMessage = "Bad Request: The difficulty level {0} does not exist sent is not valid. Please enter one of the following:" +
                    "\"beginner\", \"intermediate\", \"expert\", \"1\", \"2\", \"3\".";
                return gameResultsDTO;
            }
            
            if(difficulty.ToLower().Equals("beginner") || difficulty.Equals("1"))
            {
                difficultyLevel = 1;
            } 
            else if(difficulty.ToLower().Equals("intermediate") || difficulty.Equals("2"))
            {
                difficultyLevel = 2;
            }
            else if (difficulty.ToLower().Equals("expert") || difficulty.Equals("3"))
            {
                difficultyLevel = 3;
            }

            if (userId <= 0)
            {
                gameResultsDTO = new GameResultsDTO();
                gameResultsDTO.ErrorCode = 400;
                gameResultsDTO.ErrorMessage = "Bad Request: The user id sent is not valid";
                return gameResultsDTO;
            }
            else
            {
                GameResultsBusinessService service = new GameResultsBusinessService();
                if (service.UserExists(userId))
                {
                    gameResultsDTO = new GameResultsDTO();
                    gameResultsDTO.ErrorCode = 0;
                    gameResultsDTO.ErrorMessage = "OK";
                    gameResultsDTO.GameResults = service.GetGameResultsForUserAndGameDifficulty(userId, difficultyLevel);
                    return gameResultsDTO;
                }
                else
                {
                    gameResultsDTO = new GameResultsDTO();
                    gameResultsDTO.ErrorCode = 404;
                    gameResultsDTO.ErrorMessage = "Not Found: There are no resources for the user with id: " + userId.ToString() + ".";
                    return gameResultsDTO;
                }

            }
        }

        public GameResultsDTO GetGameResultsForGameDifficulty(string limit, string difficulty)
        {
            int limitInt = 0;
            Int32.TryParse(limit, out limitInt);
            int difficultyLevel = 0;
            GameResultsDTO gameResultsDTO;

            if (!difficulty.ToLower().Equals("beginner") && !difficulty.ToLower().Equals("intermediate") && !difficulty.ToLower().Equals("expert")
                && !difficulty.ToLower().Equals("1") && !difficulty.ToLower().Equals("2") && !difficulty.ToLower().Equals("3"))
            {
                gameResultsDTO = new GameResultsDTO();
                gameResultsDTO.ErrorCode = 400;
                gameResultsDTO.ErrorMessage = "Bad Request: The difficulty level {0} does not exist sent is not valid. Please enter one of the following:" +
                    "\"beginner\", \"intermediate\", \"expert\", \"1\", \"2\", \"3\".";
                return gameResultsDTO;
            }

            if (difficulty.ToLower().Equals("beginner") || difficulty.Equals("1"))
            {
                difficultyLevel = 1;
            }
            else if (difficulty.ToLower().Equals("intermediate") || difficulty.Equals("2"))
            {
                difficultyLevel = 2;
            }
            else if (difficulty.ToLower().Equals("expert") || difficulty.Equals("3"))
            {
                difficultyLevel = 3;
            }



            GameResultsBusinessService service = new GameResultsBusinessService();
            gameResultsDTO = new GameResultsDTO();
            gameResultsDTO.ErrorCode = 0;
            gameResultsDTO.ErrorMessage = "OK";
            gameResultsDTO.GameResults = service.GetGameResultsForDifficulty(limitInt, difficultyLevel);
            return gameResultsDTO;
        }
    }
}