using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[ , ] Grid { get; set; }
        double Difficulty { get; set; } = .05;
        public int BombsCreated { get; set; } = 0;
        public int VisitedSpaces { get; set; } = 0;

        Random rand = new Random();

        //constructor
        public Board(int size)
        {
            Size = size;
            Grid = new Cell[size, size];

            //initialize the cells in the array
            for (int row = 0; row < size; row++)
            {
                for(int col = 0; col < size; col++)
                    Grid[row, col] = new Cell();
            }
        }

        /*Create the bombs
         * - The Difficulty property determines the percentage 
         *   of the board that is bombs.
         */
        public void SetupLiveNeighbors()
        {
            double bombsNeeded = (Size * Size * Difficulty);
            while (BombsCreated + 1 <= bombsNeeded)
            {
                int row = rand.Next(Size - 1);
                int column = rand.Next(Size - 1);

                if(!Grid[row, column].Live)
                {
                    Grid[row, column].Live = true;
                    Grid[row, column].LiveNeighbors = 9;
                    BombsCreated++;
                }
            }
        }

        /*Goes through each cell in the board and if it is a bomb
            it adds 1 to each of its surrounding cells 
            LiveNeighbors property.
        */
        public void CalculateLiveNeighbors()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
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
            Grid[row, col].Visited = true;
            VisitedSpaces++;
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

        public bool isSafeCell(int row, int col)
        {
            return (row >= 0 && row < Size && col >= 0 && col < Size && !Grid[row, col].Visited);
        }
    }
}
