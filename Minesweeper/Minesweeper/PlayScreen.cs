/*

    Joshua Scott
    
    GCU CST-227
    
    This Code is my own work

*/
using System;
using System.Diagnostics;
using System.Windows.Forms;
using MilestoneProject;

namespace Minesweeper
{
    public partial class PlayScreen : Form
    {
        public Board gameBoard;
        public GameCell[,] square;
        int size;
        public static Stopwatch watch = new Stopwatch();
        public int checkedCells;
        public int checkedCellsCounter;
        public int dificulty;

        public PlayScreen(int Difficulty)
        {
            InitializeComponent();
            this.dificulty = Difficulty;
            checkedCells = 0;
            size = dificulty * 5;
            checkedCellsCounter = size * size;
            gameBoard = new Board(size);
            gameBoard.InitializeBoard();
            gameBoard.PlantBombs();
            gameBoard.CalculatePlantedBombs();

            this.Width = 50 * size;
            this.Height = Width;

            square = new GameCell[size, size];

            for(int x = 1; x < size; x++)
            {
                for(int y = 1; y < size; y++)
                {
                    bool Visited = gameBoard.GameBoard.Find(cell => cell.Column == y && cell.Row == x).Visited;
                    int Neighbors = gameBoard.GameBoard.Find(cell => cell.Column == y && cell.Row == x).LiveNeighbors;
                    square[x, y] = new GameCell();
                    int X = x * 46;
                    int Y = y * 46;
                    square[x, y].Location = new System.Drawing.Point(X, Y);
                    square[x, y].Size = new System.Drawing.Size(45, 45);
                    square[x, y].row = x;
                    square[x, y].col = y;
                    square[x, y].visited = Visited;
                    square[x, y].live = gameBoard.GameBoard.Find(cell => cell.Column == y && cell.Row == x).Live;
                    if (square[x, y].live)
                    {
                        square[x, y].visited = true;
                        checkedCells++;
                    }
                    square[x, y].liveNeighbors = Neighbors;
                    square[x, y].parent = this;
                    this.Controls.Add(square[x, y]);
                }
            }
            watch.Start();
        }

        private void PlayScreen_Load(object sender, EventArgs e)
        {

        }

        public void ShowZeros(int x, int y)
        {
            gameBoard.floodFill(x, y);
            for (int X = 1; X < size; X++)
            {
                for (int Y = 1; Y < size; Y++)
                {
                    if (gameBoard.GameBoard.Find(cell => cell.Column == Y && cell.Row == X).Visited)
                    {
                        square[X, Y].ZeroReveal();
                    }
                }
            }
            if (checkedCells == checkedCellsCounter)
                Victory();
        }

        public void BombHit()
        {
            watch.Stop();
            string time = watch.Elapsed.Seconds.ToString();
            string text = "You hit a bomb! you survived for: " + time + " Seconds";
            MessageBox.Show(text);
            HighScore hs = new HighScore();
            hs.Show();
            this.Close();
        }

        public void Victory()
        {
            watch.Stop();
            string time = watch.Elapsed.Seconds.ToString();
            string text = "You Win! It took " + time + " Seconds to clear the game";
            MessageBox.Show(text);
            HighScore hs = new HighScore();
            hs.CheckScore(dificulty.ToString(), time);
            hs.Show();
            this.Close();
        }

    }
}
