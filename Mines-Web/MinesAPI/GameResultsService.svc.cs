using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MinesAPI.DTOs;
using MinesAPI.Models;

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
        public GameResultsDTO GetAllGameResults()
        {
            GameResultsDTO gameResultsDTO = new GameResultsDTO();
            gameResultsDTO.ErrorCode = 0;
            gameResultsDTO.ErrorMessage = "OK";
            gameResultsDTO.GameResults = gameResults;
            return gameResultsDTO;
        }
    }
}
