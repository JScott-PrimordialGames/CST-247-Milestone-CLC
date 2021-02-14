using Mines_Web.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mines_Web.Models;
using Newtonsoft.Json;

namespace Mines_Web.Services.Business
{
    public class GameService
    {
        GamesDAO service = new GamesDAO();

        public bool SaveGame(UserModel user, BoardModel board)
        {
            int userID = user.ID;
            string boardJsonString = JsonConvert.SerializeObject(board);
            return service.SaveGame(userID, boardJsonString);
        }

        public BoardModel LoadGame(int gameID)
        {
            string boardJsonString = service.LoadGame(gameID);
            BoardModel board = JsonConvert.DeserializeObject<BoardModel>(boardJsonString);
            return board;
            
        }

        public List<int> GetThreeSavedGamesByUserID(int userID)
        {
            return service.GetThreeSavedGamesByUserID(userID);
        }

    }
}