using Mines_Web.Models;
using Mines_Web.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mines_Web.Services.Business
{
    public class ScoreService
    {
        ScoreDAO service = new ScoreDAO();

        public bool AddScore(UserModel user, float score, int difficulty)
        {
            int userID = user.ID;
            return service.AddScore(userID, score, difficulty);
        }
    }
}