using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone_MineSweeper_GUI
{
    public partial class Form_Game : Form
    {
        Board myBoard;
        public Button[,] btnGrid;
        bool win = false;
        int difficulty;
        Stopwatch watch = new Stopwatch();
        decimal minutes, seconds;
        public static string highScoresFilePath = "";
        public static List<string> leaderBoard;


        public Form_Game(int size, string path)
        {
            InitializeComponent();
            myBoard = new Board(size);
            myBoard.SetupLiveNeighbors();
            myBoard.CalculateLiveNeighbors();
            btnGrid = new Button[myBoard.Size, myBoard.Size];
            PopulateGrid();
            watch.Start();
            highScoresFilePath = path;
            difficulty = size;
            lbl_numOfBombs.Text = myBoard.BombsCreated.ToString();
        }


        public void PopulateGrid()
        {
            int buttonSize = panel1.Width / myBoard.Size;
            panel1.Height = panel1.Width;

            for(int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    // create the button
                    btnGrid[r, c] = new Button();

                    // make the button square and the right size
                    btnGrid[r, c].Width = buttonSize;
                    btnGrid[r, c].Height = buttonSize;

                    // place the button in panel1
                    panel1.Controls.Add(btnGrid[r, c]);

                    // add the same click event to each button
                    btnGrid[r, c].MouseDown += Grid_Button_MouseDown;

                    // set button location
                    btnGrid[r, c].Location = new Point(buttonSize * c, buttonSize * r);

                    // holds the button location as a string
                    btnGrid[r, c].Tag = r.ToString() + "|" + c.ToString();
                    
                    // set the layout for when image is added to button
                    btnGrid[r, c].BackgroundImageLayout = ImageLayout.Stretch;
                }

            }
        }

        private void Grid_Button_MouseDown(object sender, MouseEventArgs e)
        {
            Button buttonPressed = (Button)sender; // create a reference for the button that was clicked
            string[] coordinates = buttonPressed.Tag.ToString().Split('|'); // create array with x and y coordinates of the button
            
            // store the x and y coordinates of the button
            int r = int.Parse(coordinates[0]);
            int c = int.Parse(coordinates[1]);

            // performs different operations depending on if right or left mouse click
            switch (MouseButtons)
            {
                case MouseButtons.Left: // check if cell is a bomb
                    if (!myBoard.Grid[r, c].Flagged && !myBoard.Grid[r, c].Visited)
                    {
                        // if the cell is a bomb
                        if (myBoard.Grid[r, c].Live) { 
                            EndGame();
                            break;
                        }
                        // if the cell is not a bomb, check if you won
                        else if ((myBoard.Size * myBoard.Size) - (myBoard.VisitedSpaces + 1) <= myBoard.BombsCreated)
                        {
                            win = true;
                            EndGame();
                            break;
                        }
                        // if the cell is not a bomb and the cell has 0 live neighbors
                        else if (myBoard.Grid[r, c].LiveNeighbors == 0)
                        {
                            myBoard.FloodFill(r, c);
                            // show buttons that have been visited
                            for (int r2 = 0; r2 < myBoard.Size; r2++)
                            {
                                for (int c2 = 0; c2 < myBoard.Size; c2++)
                                {
                                    if (myBoard.Grid[r2, c2].Visited)
                                    {
                                        if (myBoard.Grid[r2, c2].LiveNeighbors == 0)
                                        {
                                            btnGrid[r2, c2].BackColor = Color.White;
                                        }
                                        else
                                        {
                                            btnGrid[r2, c2].Text = myBoard.Grid[r2, c2].LiveNeighbors.ToString();
                                            btnGrid[r2, c2].BackColor = Color.White;
                                        }
                                    }
                                }
                            }
                        }
                        // if the cell you clicked is not a bomb, and has live neighbors
                        else
                        {
                            // update button color and text to show how many live neighbors
                            btnGrid[r, c].BackColor = Color.White;
                            btnGrid[r, c].Text = myBoard.Grid[r, c].LiveNeighbors.ToString();
                            myBoard.Grid[r, c].Visited = true;
                            myBoard.VisitedSpaces++;
                        }
                    }

                    break;

                case MouseButtons.Right: // mark the cell as a bomb
                    if (!myBoard.Grid[r, c].Flagged)
                    {
                        btnGrid[r, c].BackgroundImage = Properties.Resources.BombFlag;
                        myBoard.Grid[r, c].Flagged = true;
                    } else
                    {
                        btnGrid[r, c].BackgroundImage = default;
                        myBoard.Grid[r, c].Flagged = false;
                    }


                    break;
            }
        }


        // called when the play either wins or loses the game
        private void EndGame()
        {
            watch.Stop();
            // this loop will reveal the full board when the game is over.
            for(int r = 0; r < myBoard.Size; r++)
            {
                for(int c = 0; c< myBoard.Size; c++)
                {
                    if (myBoard.Grid[r, c].Live)
                    {
                        btnGrid[r, c].BackgroundImage = Properties.Resources.bomb;
                    } else
                    {
                        if(myBoard.Grid[r, c].LiveNeighbors != 0)
                            btnGrid[r, c].Text = myBoard.Grid[r, c].LiveNeighbors.ToString();
                    }
                }
            }
            if (win)
            {
                // save amount of time it took to win
                TimeSpan timeElapsed = watch.Elapsed;

                // calculate the final score
                // score goes up with shorter time and higher difficulty
                decimal score = 
                    (decimal)Math.Round(1 / timeElapsed.TotalSeconds * Math.Pow(difficulty, 5), 0);
                
                Form_RecordScore form = new Form_RecordScore(difficulty, timeElapsed, score, highScoresFilePath);
                form.ShowDialog();

                // shows the updated leaderboard in a messageBox
                DisplayLeaderBoard();
                
            }
            else
            {
                MessageBox.Show("Sorry but you lost. Better Luck next time!");

                // shows the updated leaderboard in a messageBox
                DisplayLeaderBoard();
            }
        }

        // resets the board and timer so the player can start a fresh game
        private void btn_newGame_Click(object sender, EventArgs e)
        {
            // remove all buttons currently in panel1
            panel1.Controls.Clear();

            win = false;
            myBoard = new Board(difficulty);
            myBoard.SetupLiveNeighbors();
            myBoard.CalculateLiveNeighbors();
            btnGrid = new Button[myBoard.Size, myBoard.Size];
            PopulateGrid();
            watch.Restart();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            minutes = (decimal)watch.ElapsedMilliseconds / 60000;
            seconds = (watch.ElapsedMilliseconds % 60000) / 1000;
            lbl_timer.Text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }

        private void btn_viewLeaderboard_Click(object sender, EventArgs e)
        {
            DisplayLeaderBoard();
        }

        private void DisplayLeaderBoard()
        {

            ////////////////////////////////
            
            leaderBoard = File.ReadAllLines(highScoresFilePath).ToList();
            // use linq statement to get top 5 from leaderboard list
            leaderBoard = leaderBoard.Take(5).ToList();
            string result = "Name\tScore\n";
            foreach(string s in leaderBoard)
            {
                string[] entries = s.Split('|');
                string name = entries[0];
                int difficulty = int.Parse(entries[1]);
                TimeSpan timeElapsed = TimeSpan.Parse(entries[2]);
                decimal score = decimal.Parse(entries[3]);

                PlayerStats ps = new PlayerStats(name, difficulty, timeElapsed, score);
                result += ps.Display() + "\n";
            }


            //////////////////////////////////


            MessageBox.Show(result);
        }
    }
}
