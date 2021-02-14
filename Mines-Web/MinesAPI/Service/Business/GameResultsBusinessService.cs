using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinesAPI.Service.Data;
using MinesAPI.Models;

namespace MinesAPI.Service.Business
{
    public class GameResultsBusinessService
    {
        GameResultsDAO gameResultsDAO = new GameResultsDAO();

        public List<GameResultsModel> GetGameResults(int limit = 0)
        {
            return gameResultsDAO.GetAllUsers(limit);
        }
    }
}