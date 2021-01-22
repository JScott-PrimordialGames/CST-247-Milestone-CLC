using Mines_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mines_Web.Controllers
{
    public class GameCenterController : Controller
    {
        // GET: GameCenter
        public ActionResult Index()
        {
            return View("GameCenter");
        }

        public ActionResult LoadGameBoard()
        {
            BoardModel board = new BoardModel(BoardModel.Difficulty.Intermediate);
            return PartialView("_GameBoard", board);
        }
    }
}