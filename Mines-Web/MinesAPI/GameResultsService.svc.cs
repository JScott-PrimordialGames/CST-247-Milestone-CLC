using System;
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
