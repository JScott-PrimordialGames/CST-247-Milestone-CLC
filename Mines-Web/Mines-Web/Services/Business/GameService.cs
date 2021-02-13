using Mines_Web.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mines_Web.Services.Business
{
    public class GameService
    {
        GamesDAO service = new GamesDAO();

        public bool SaveGame(GameObject gameObject)
        {
            return service.SaveGame(gameObject);
        }

    }
}