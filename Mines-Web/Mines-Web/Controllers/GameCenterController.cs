using Mines_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using Mines_Web.Services.Business;
using Mines_Web.Services.Data;

namespace Mines_Web.Controllers
{
    public class GameCenterController : Controller
    {
        public static BoardModel board = new BoardModel(BoardModel.Difficulty.Beginner);
        //public BoardModel board;
        public static BoardModel.Difficulty gameDifficulty = BoardModel.Difficulty.Beginner;

        GameService gameService = new GameService();
        ScoreService scoreService = new ScoreService();

        [NonAction]
        public void getBoard()
        {
            if (Session["board"] == null)
            {
                board = new BoardModel(BoardModel.Difficulty.Beginner);
                Session["board"] = board;
            }
            else
            {
                board = (BoardModel)Session["board"];
            }
        }

        [CustomAuthorization]
        // GET: GameCenter
        public ActionResult Index()
        {
            board = new BoardModel(BoardModel.Difficulty.Beginner);
            Session["board"] = board;
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

            if(board.VisitedSpaces == 0)
            {
                board.StartClock(); 
            }

            //check that cell is not flagged, and not already visited
            if (!board.Grid[col, row].Flagged && !board.Grid[col, row].Visited)
            {
                // if the cell is a bomb
                if (board.Grid[col, row].Live)
                {
                    board.Grid[col, row].Detonated = true;
                    board.GameLost();
                    return PartialView("_GameBoard", board);
                }
                // if the cell is not a bomb, check if you won
                else if ((board.NumOfRows * board.NumOfColumns) - (board.VisitedSpaces + 1) <= board.Mines)
                {
                    board.StopClock();
                    UserModel user = (UserModel)Session["user"];
                    ViewBag.score = board.GetScore();

                    bool succeeded = scoreService.AddScore(user, board.GetScore(), (int)gameDifficulty + 1);

                    board.Grid[col, row].Visited = true;
                    board.VisitedSpaces++;
                    board.GameWon = true;
                    return PartialView("_GameBoard", board);
                }
                // if the cell is not a bomb and the cell has 0 live neighbors
                else if (board.Grid[col, row].LiveNeighbors == 0)
                {
                    board.FloodFill(col, row);
                    return PartialView("_GameBoard", board);
                }
                // if the cell you clicked is not a bomb, and has live neighbors
                else
                {
                    board.Grid[col, row].Visited = true;
                    board.VisitedSpaces++;
                    return PartialView("_GameBoard", board);
                }
            } else
            {
                return PartialView("_GameBoard", board);
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

        [HttpPost]
        public ActionResult SaveGame()
        {
            if (!board.isGameLost && !board.GameWon)
            {
                board.StopClock();
                UserModel user = (UserModel)Session["user"];
                gameService.SaveGame(user, board);
            }
            return View("GameCenter");

        }

        public ActionResult LoadGame(int gameID)
        {
            board = gameService.LoadGame(gameID);
            board.StartClock();

            return View("GameCenter");
        }

        public ActionResult LoadSavedGamesList()
        {
            List<GameObject> gamesList = gameService.GetThreeSavedGamesByUserID(((UserModel)Session["user"]).ID);

            return PartialView("_SavedGames", gamesList);
        }
    }
}