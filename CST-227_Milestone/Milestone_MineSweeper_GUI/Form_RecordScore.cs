using ClassLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone_MineSweeper_GUI
{
    public partial class Form_RecordScore : Form
    {
        int difficultyLevel;
        TimeSpan timeElapsed;
        decimal score;
        static string highScoresFilePath = "";
        List<string> highScoresList;
        public Form_RecordScore(int playerDifficulty, TimeSpan playerTimeElapsed, decimal playerScore, string path)
        {
            InitializeComponent();
            difficultyLevel = playerDifficulty;
            timeElapsed = playerTimeElapsed;
            score = playerScore;
            highScoresFilePath = path;
            highScoresList = File.ReadAllLines(highScoresFilePath).ToList();
            lbl_score.Text = score.ToString();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (tb_playerName.Text.Length < 6)
            {
                PlayerStats playerStats = new PlayerStats(tb_playerName.Text, difficultyLevel, timeElapsed, score);
                addToHighScores(playerStats);
            } else
            {
                lbl_errorMessage.Visible = true;
            }
        }

        // adds a string to represent the PlayerStats object to the highscores.txt file
        public void addToHighScores(PlayerStats ps)
        {
            for(int i = 0; i < highScoresList.Count; i++)
            {
                string[] entries = highScoresList[i].Split('|');
                if(decimal.Parse(entries[3]) < ps.Score)
                {
                    highScoresList.Insert(i, ps.ToString()); // add score to the games leaderboard
                    File.WriteAllLines(highScoresFilePath, highScoresList);
                    this.Close();
                    return;
                }
            }
        }
    }
}
