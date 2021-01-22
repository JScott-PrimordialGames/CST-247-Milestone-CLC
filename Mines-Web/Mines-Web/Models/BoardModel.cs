using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mines_Web.Models
{
    public class BoardModel
    {
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

        public int ColumnSize { get; private set; }
        public int RowSize { get; private set; }
        public int Mines { get; private set; }

        private enum HardSetup : int
        {
            Rows = 16,
            Columns = 30,
            Mines = 99
        }

        public CellModel[,] Grid { get; set; }

        public BoardModel(BoardModel.Difficulty difficulty)
        {
            if(difficulty == BoardModel.Difficulty.Beginner)
            {
                RowSize = (int)BoardModel.BeginnerSetup.Rows;
                ColumnSize = (int)BoardModel.BeginnerSetup.Columns;
                Mines = (int)BoardModel.BeginnerSetup.Mines;
            } else if(difficulty == BoardModel.Difficulty.Intermediate)
            {
                RowSize = (int)BoardModel.IntermediateSetup.Rows;
                ColumnSize = (int)BoardModel.IntermediateSetup.Columns;
                Mines = (int)BoardModel.IntermediateSetup.Mines;
            } else
            {
                RowSize = (int)BoardModel.HardSetup.Rows;
                ColumnSize = (int)BoardModel.HardSetup.Columns;
                Mines = (int)BoardModel.HardSetup.Mines;
            }

            Grid = new CellModel[RowSize, ColumnSize];
            for(int row = 0; row < RowSize; row++)
            {
                for(int column = 0; column < ColumnSize; column++)
                {
                    Grid[row, column] = new CellModel();
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
                int row = rand.Next(RowSize - 1);
                int col = rand.Next(ColumnSize - 1);

                if (Grid[row, col].Live == false)
                {
                    Grid[row, col].Live = true;
                    Grid[row, col].LiveNeighbors = 9;
                    mines--;
                }
            }
        }
    
        private void CalculateLiveNeighbors()
        {
            for (int row = 0; row < RowSize; row++)
            {
                for (int col = 0; col < ColumnSize; col++)
                {
                    if (Grid[row, col].Live == true)
                    {
                        if (isSafeCell(row - 1, col)) Grid[row - 1, col].LiveNeighbors++;
                        if (isSafeCell(row - 1, col - 1)) Grid[row - 1, col - 1].LiveNeighbors++;
                        if (isSafeCell(row - 1, col + 1)) Grid[row - 1, col + 1].LiveNeighbors++;
                        if (isSafeCell(row, col - 1)) Grid[row, col - 1].LiveNeighbors++;
                        if (isSafeCell(row, col + 1)) Grid[row, col + 1].LiveNeighbors++;
                        if (isSafeCell(row + 1, col - 1)) Grid[row + 1, col - 1].LiveNeighbors++;
                        if (isSafeCell(row + 1, col)) Grid[row + 1, col].LiveNeighbors++;
                        if (isSafeCell(row + 1, col + 1)) Grid[row + 1, col + 1].LiveNeighbors++;

                    }
                }
            }
        }

        public void FloodFill(int row, int col)
        {
            Grid[row, col].Clicked = true;
            if (Grid[row, col].LiveNeighbors == 0)
            {
                if (isSafeCell(row - 1, col - 1))
                    FloodFill(row - 1, col - 1);
                if (isSafeCell(row - 1, col))
                    FloodFill(row - 1, col);
                if (isSafeCell(row - 1, col + 1))
                    FloodFill(row - 1, col + 1);
                if (isSafeCell(row, col - 1))
                    FloodFill(row, col - 1);
                if (isSafeCell(row, col + 1))
                    FloodFill(row, col + 1);
                if (isSafeCell(row + 1, col - 1))
                    FloodFill(row + 1, col - 1);
                if (isSafeCell(row + 1, col))
                    FloodFill(row + 1, col);
                if (isSafeCell(row + 1, col + 1))
                    FloodFill(row + 1, col + 1);
            }
        }
        private bool isSafeCell(int row, int col)
        {
            return (row >= 0 && row < RowSize && col >= 0 && col < ColumnSize && !Grid[row, col].Clicked);
        }

    }
}