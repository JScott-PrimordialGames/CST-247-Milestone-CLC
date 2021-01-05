using ClassLibrary;
using System;
using System.Drawing;
using System.Linq.Expressions;

namespace milestone_MineSweeper_ConsoleApp
{
    class Program
    {
        static Board myBoard = new Board(10);
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to MineSweeper!");

            myBoard.SetupLiveNeighbors();
            myBoard.CalculateLiveNeighbors();
            PrintBoardDuringGame();
            GameLoop();
        }

        static void PrintBoardDuringGame()
        {
            Console.WriteLine();

            // top line numbers columns
            for (int i = 0; i < myBoard.Size; i++)
            {
                if (i < 10)
                {
                    Console.Write("+ " + i + " ");
                }
                else
                {
                    Console.Write("+ " + i);
                }
            }
            Console.WriteLine("+");
            myBoard.MakeLine();

            // Print the LiveNeighbors property for every cell
            for (int row = 0; row < myBoard.Size; row++) //
            {
                for (int col = 0; col < myBoard.Size; col++)
                {
                    if (myBoard.Grid[row, col].Visited == true)
                    {
                        if(myBoard.Grid[row, col].LiveNeighbors == 0)
                        {
                            Console.Write("|   ");
                        }
                        else if(myBoard.Grid[row, col].LiveNeighbors < 9)
                        {
                            Console.Write("| ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(myBoard.Grid[row, col].LiveNeighbors + " ");
                            Console.ResetColor();
                        } else
                        {
                            Console.Write("| ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("B ");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.Write("| " + "?" + " ");
                    }
                }
                Console.Write("| " + row + "\n");
                myBoard.MakeLine();
            }
            Console.WriteLine();
        }

        /* runs the game. 
         *  - gathers user selected row and column input 
            - checks if they won/lost the game
            - uses PrintBoardDuringGame() method to print board
        */
        static void GameLoop()
        {
            bool endGame = false;
            int row, col, numVisited = 0;
            int nonBombTiles = (myBoard.Size * myBoard.Size) - myBoard.BombsCreated;

            //Let the user know how many bombs there are
            Console.WriteLine("there are " + myBoard.BombsCreated + " bombs");

            while(endGame != true)
            {
                Console.Write("Please enter a Row #: ");
                bool goodRow = int.TryParse(Console.ReadLine(), out row);
                Console.Write("Please enter a Column #: ");
                bool goodCol = int.TryParse(Console.ReadLine(), out col);

                // check that the input is valid
                if (goodRow && goodCol && row >= 0 && row < myBoard.Size && col >= 0 && col < myBoard.Size) 
                {

                    // if selected cell is a bomb, you lose
                    if (myBoard.Grid[row, col].Live) 
                    {
                        myBoard.Grid[row, col].Visited = true;
                        PrintBoardDuringGame();
                        endGame = true;
                        Console.WriteLine("BOOMMMMM Game over! You clicked on a bomb! Thanks for playing!");
                    }
                    else // if selected cell is not a bomb, mark the cell visited and print the board
                    {
                        if (!myBoard.Grid[row, col].Visited) // make sure that space hasn't been visited
                        {
                            numVisited++;
                            myBoard.FloodFill(row, col);
                            myBoard.Grid[row, col].Visited = true;
                        }
                        PrintBoardDuringGame();
                    }
                    
                    // check if user has won
                    if(numVisited == nonBombTiles)
                    {
                        endGame = true;
                        Console.WriteLine("Phhhhew that was close!! Great Job! You won that one!");
                    }
                }
                else
                {
                    Console.WriteLine("\nYou entered an invalid argument. Please try again.");
                }
            }
        }
    }
}
