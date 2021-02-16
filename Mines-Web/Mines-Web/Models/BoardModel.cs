using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;


namespace Mines_Web.Models
{
    public class BoardModel
    {
        public int NumOfColumns { get; set; }
        public int NumOfRows { get; set; }
        public int Mines { get; set; }
        public CellModel[,] Grid { get; set; }
        public int VisitedSpaces { get; set; } = 0;
        public bool GameWon { get; set; } = false;

        public bool isGameLost { get; set; } = false;

        public long Score { get; set; } = 0;


        public Stopwatch gameClock { get;  set; }

        public enum Difficulty : int
        {
            Beginner = 0,
            Intermediate = 1,
            Hard = 2
        }

        private enum BeginnerSetup : int
        {
            Rows = 9,
            Columns = 9,
            Mines = 10
        }

        private enum IntermediateSetup : int
        {
            Rows = 16,
            Columns = 16,
            Mines = 40
        }


        private enum HardSetup : int
        {
            Rows = 16,
            Columns = 30,
            Mines = 99
        }


        public BoardModel(BoardModel.Difficulty difficulty)
        {
            gameClock = new Stopwatch();
            if (difficulty == BoardModel.Difficulty.Beginner)
            {
                NumOfRows = (int)BoardModel.BeginnerSetup.Rows;
                NumOfColumns = (int)BoardModel.BeginnerSetup.Columns;
                Mines = (int)BoardModel.BeginnerSetup.Mines;
            } else if(difficulty == BoardModel.Difficulty.Intermediate)
            {
                NumOfRows = (int)BoardModel.IntermediateSetup.Rows;
                NumOfColumns = (int)BoardModel.IntermediateSetup.Columns;
                Mines = (int)BoardModel.IntermediateSetup.Mines;
            } else
            {
                NumOfRows = (int)BoardModel.HardSetup.Rows;
                NumOfColumns = (int)BoardModel.HardSetup.Columns;
                Mines = (int)BoardModel.HardSetup.Mines;
            }

            Grid = new CellModel[NumOfColumns, NumOfRows];
            for(int row = 0; row < NumOfRows; row++)
            {
                for(int col = 0; col < NumOfColumns; col++)
                {
                    Grid[col, row] = new CellModel(col, row);
                }
            }

            SetupMines();
            CalculateLiveNeighbors();
        }

        private void SetupMines()
        {
            Random rand = new Random();
            int mines = Mines;
            while(mines > 0)
            {
                int row = rand.Next(NumOfRows - 1);
                int col = rand.Next(NumOfColumns - 1);

                if (Grid[col, row].Live == false)
                {
                    Grid[col, row].Live = true;
                    Grid[col, row].LiveNeighbors = 9;
                    mines--;
                }
            }
        }
    
        private void CalculateLiveNeighbors()
        {
            for (int row = 0; row < NumOfRows; row++)
            {
                for (int col = 0; col < NumOfColumns; col++)
                {
                    if (Grid[col, row].Live == true)
                    {
                        if (isSafeCell(col - 1, row)) 
                            Grid[col - 1, row].LiveNeighbors++;
                        if (isSafeCell(col - 1, row - 1)) 
                            Grid[col - 1, row - 1].LiveNeighbors++;
                        if (isSafeCell(col - 1, row + 1)) 
                            Grid[col - 1, row + 1].LiveNeighbors++;
                        if (isSafeCell(col, row - 1)) 
                            Grid[col, row - 1].LiveNeighbors++;
                        if (isSafeCell(col, row + 1)) 
                            Grid[col, row + 1].LiveNeighbors++;
                        if (isSafeCell(col + 1, row - 1)) 
                            Grid[col + 1, row - 1].LiveNeighbors++;
                        if (isSafeCell(col + 1, row)) 
                            Grid[col + 1, row].LiveNeighbors++;
                        if (isSafeCell(col + 1, row + 1)) 
                            Grid[col + 1, row + 1].LiveNeighbors++;

                    }
                }
            }
        }

        public void FloodFill(int col, int row)
        {
            Grid[col, row].Visited = true;
            VisitedSpaces++;
            if (Grid[col, row].LiveNeighbors == 0)
            {
                if (isSafeCell(col - 1, row - 1))
                    FloodFill(col - 1, row - 1);
                if (isSafeCell(col - 1, row))
                    FloodFill(col - 1, row);
                if (isSafeCell(col - 1, row + 1))
                    FloodFill(col - 1, row + 1);
                if (isSafeCell(col, row - 1))
                    FloodFill(col, row - 1);
                if (isSafeCell(col, row + 1))
                    FloodFill(col, row + 1);
                if (isSafeCell(col + 1, row - 1))
                    FloodFill(col + 1, row - 1);
                if (isSafeCell(col + 1, row))
                    FloodFill(col + 1, row);
                if (isSafeCell(col + 1, row + 1))
                    FloodFill(col + 1, row + 1);
            }
        }
        private bool isSafeCell(int col, int row)
        {
            return (row >= 0 && row < NumOfRows && col >= 0 && col < NumOfColumns && !Grid[col, row].Visited);
        }

        public void GameLost()
        {
            isGameLost = true;
            for(int row = 0; row < NumOfRows; row++)
            {
                for(int col = 0; col < NumOfColumns; col++)
                {
                    Grid[col, row].Visited = true;
                }
            }
        }

        public void StartClock()
        {  
            gameClock.Start();
        }

        public void StopClock()
        {
            gameClock.Stop();
            this.Score += gameClock.ElapsedMilliseconds;
            gameClock = new Stopwatch();
        }

        public string GetPlayTime()
        {
            return ((int)(this.Score + gameClock.ElapsedMilliseconds) / 1000).ToString();
        }

        public float GetScore()
        {
            return ((float)this.Score)/1000f;

        }
    }
}