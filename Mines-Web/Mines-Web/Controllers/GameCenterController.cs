using Mines_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace Mines_Web.Controllers
{
    public class GameCenterController : Controller
    {
        public static BoardModel board = new BoardModel(BoardModel.Difficulty.Beginner);
        public static BoardModel.Difficulty gameDifficulty = BoardModel.Difficulty.Beginner;
        
        // GET: GameCenter
        public ActionResult Index()
        {
            return View("GameCenter");
        }

        public ActionResult LoadGameBoard()
        {
            return PartialView("_GameBoard", board);
        }

        public ActionResult LoadNewGameBoard(string difficulty = "Beginner")
        {
            if (difficulty == "Beginner")
            {
                gameDifficulty = BoardModel.Difficulty.Beginner;
            }
            else if (difficulty == "Intermediate")
            {
                gameDifficulty = BoardModel.Difficulty.Intermediate;
            }
            else if (difficulty == "Expert")
            {
                gameDifficulty = BoardModel.Difficulty.Hard;
            } 

            board = new BoardModel(gameDifficulty);

            return View("GameCenter");
        }

        public ActionResult OnCellClick(string cellLocation)
        {
            var coordinates = cellLocation.Split(' ');
            int col = int.Parse(coordinates[0]);
            int row = int.Parse(coordinates[1]);

            //board.Grid[col, row].Visited = true;
            //return View("GameCenter");



            //check that cell is not flagged, and not already visited
            if (!board.Grid[col, row].Flagged && !board.Grid[col, row].Visited)
            {
                // if the cell is a bomb
                if (board.Grid[col, row].Live)
                {
                    board.Grid[col, row].Detonated = true;
                    board.GameLost();
                    return View("GameCenter");
                    //return Content("you lost!");
                }
                // if the cell is not a bomb, check if you won
                else if ((board.NumOfRows * board.NumOfColumns) - (board.VisitedSpaces + 1) <= board.Mines)
                {
                    board.Grid[col, row].Visited = true;
                    board.VisitedSpaces++;
                    return Content("you won!");
                }
                // if the cell is not a bomb and the cell has 0 live neighbors
                else if (board.Grid[col, row].LiveNeighbors == 0)
                {
                    board.FloodFill(col, row);
                    return View("GameCenter");
                }
                // if the cell you clicked is not a bomb, and has live neighbors
                else
                {
                    board.Grid[col, row].Visited = true;
                    board.VisitedSpaces++;
                    return View("GameCenter");
                }
            } else
            {
                return View("GameCenter");
            }
        }

        public ActionResult OnCellRightClick(string cellLocation)
        {
            var coordinates = cellLocation.Split(' ');
            int col = int.Parse(coordinates[0]);
            int row = int.Parse(coordinates[1]);
            board.Grid[col, row].Flagged = !board.Grid[col, row].Flagged;
            return View("GameCenter");
        }
    }
}