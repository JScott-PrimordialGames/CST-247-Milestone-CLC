/*

    Joshua Scott
    
    GCU CST-227
    
    This Code is my own work

*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace MilestoneProject
{
    public class Board
    {
        public int BoardSize;
        public List<Cell> GameBoard { get; } = new List<Cell>();
        float Dificulty;

        public Board(int size)
        {
            BoardSize = size;
        }

        public void InitializeBoard()
        {
            for (int x = 1; x <= BoardSize; x++ )
            {
                for (int y = 1; y <= BoardSize; y++)
                {
                    GameBoard.Add(new Cell(x, y, false, false, 0));
                }
            }
        }

        public void PlantBombs()
        {
            int cellsPlaced = BoardSize * BoardSize;
            int NumberOfLiveBombs = (int)(cellsPlaced * .2f /**Dificulty*/);
            Random rng = new Random();
            Console.Out.WriteLine("Generating Bombs");
            for (int i = 0; i < NumberOfLiveBombs; i++)
            {
                int x = rng.Next(1, BoardSize + 1);
                int y = rng.Next( BoardSize + 1);
                Cell results = GameBoard.Find(cell => cell.Column == y && cell.Row == x && !cell.Live);
                while (results == null)
                {
                    x = rng.Next(1, BoardSize + 1);
                    y = rng.Next(1, BoardSize + 1);
                    results = GameBoard.Find(cell => cell.Column == y && cell.Row == x && !cell.Live);
                }
                results.Live = true;
            }


        }

        public void CalculatePlantedBombs()
        {
            foreach(Cell currentCell in GameBoard)
            {
                if(currentCell.Live)
                {
                    currentCell.LiveNeighbors = 9;
                    continue;
                }
                CheckTopNeighbor(currentCell);
                CheckBottomNeighbor(currentCell);
                CheckLeftNeighbor(currentCell);
                CheckRightNeighbor(currentCell);
            }
        }

        private void CheckTopNeighbor(Cell currentCell)
        {
            Cell TopNeighbor = GameBoard.Find(cell => cell.Column == currentCell.Column - 1 && cell.Row == currentCell.Row);
            if (TopNeighbor != null && TopNeighbor.Live)
            {
                currentCell.LiveNeighbors++;
            }
        }

        private void CheckBottomNeighbor(Cell currentCell)
        {
            Cell BottomhNeighbor = GameBoard.Find(cell => cell.Column == currentCell.Column + 1 && cell.Row == currentCell.Row);
            if (BottomhNeighbor != null && BottomhNeighbor.Live)
            {
                BottomhNeighbor.LiveNeighbors++;
            }
        }
        private void CheckRightNeighbor(Cell currentCell)
        {
            Cell RightNeighbor = GameBoard.Find(cell => cell.Column == currentCell.Column && cell.Row == currentCell.Row - 1);
            if (RightNeighbor != null && RightNeighbor.Live)
            {
                RightNeighbor.LiveNeighbors++;
            }
        }
        private void CheckLeftNeighbor(Cell currentCell)
        {
            Cell LeftNeighbor = GameBoard.Find(cell => cell.Column == currentCell.Column && cell.Row == currentCell.Row + 1);
            if (LeftNeighbor != null && LeftNeighbor.Live)
            {
                currentCell.LiveNeighbors++;
            }
        }


        public void floodFill(int row, int col)
        {
            Cell checkCell = GameBoard.Find(cell => cell.Row == row && cell.Column == col);
            if (checkCell != null)
            {
                if (!checkCell.Live)
                {
                    if (col > 1)
                    {
                        int val = GameBoard.Find(cell => cell.Column == col - 1 && cell.Row == row).LiveNeighbors;
                        bool visited = (GameBoard.Find(cell => cell.Column == col - 1 && cell.Row == row)).Visited;
                        if (val == 0 && !visited)
                        {
                            GameBoard.Find(cell => cell.Column == col - 1 && cell.Row == row).Visited = true;
                            floodFill(row - 1, col);
                        }
                        else if (val == 10 && !visited)
                        {
                            GameBoard.Find(cell => cell.Column == col - 1 && cell.Row == row).Visited = true;
                        }
                    }

                    if (col < this.BoardSize)
                    {
                        int val = GameBoard.Find(cell => cell.Column == col + 1 && cell.Row == row).LiveNeighbors;
                        bool visited = GameBoard.Find(cell => cell.Column == col + 1 && cell.Row == row).Visited;
                        if (val == 0 && !visited)
                        {
                            GameBoard.Find(cell => cell.Column == col + 1 && cell.Row == row).Visited = true;
                            floodFill(row + 1, col);
                        }
                        else if (val == 10 && !visited)
                        {
                            GameBoard.Find(cell => cell.Column == col + 1 && cell.Row == row).Visited = true;
                        }
                    }

                    if (row > 1)
                    {
                        int val = GameBoard.Find(cell => cell.Column == col && cell.Row == row - 1).LiveNeighbors;
                        bool visited = GameBoard.Find(cell => cell.Column == col && cell.Row == row - 1).Visited;
                        if (val == 0 && !visited)
                        {
                            GameBoard.Find(cell => cell.Column == col && cell.Row == row - 1).Visited = true;
                            floodFill(row - 1, col);
                        }
                        else if (val == 10 && !visited)
                        {
                            GameBoard.Find(cell => cell.Column == col && cell.Row == row - 1).Visited = true;
                        }
                    }

                    if (row < this.BoardSize)
                    {
                        int val = GameBoard.Find(cell => cell.Column == col && cell.Row == row + 1).LiveNeighbors;
                        bool visited = GameBoard.Find(cell => cell.Column == col && cell.Row == row + 1).Visited;
                        if (val == 0 && !visited)
                        {
                            GameBoard.Find(cell => cell.Column == col && cell.Row == row + 1).Visited = true;
                            floodFill(row, col);
                        }
                        else if (val == 10 && !visited)
                        {
                            GameBoard.Find(cell => cell.Column == col && cell.Row == row + 1).Visited = true;
                        }
                    }
                }
            }
            return;
        }
    }
}

