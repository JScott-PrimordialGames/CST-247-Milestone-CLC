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
            return PartialView("_GameBoard");
        }
    }
}