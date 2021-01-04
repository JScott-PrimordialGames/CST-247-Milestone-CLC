/*

    Joshua Scott
    
    GCU CST-227
    
    This Code is my own work

*/
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

namespace Minesweeper
{
    public partial class HighScore : Form
    {

        BindingSource HighScoreList = new BindingSource();
        List<String> lines;
        List<PlayerStats> Players;
        int LastSlot = 4;

        public string PlayerName;
        public string Dificulty;
        public string Time;


        public HighScore()
        {
            InitializeComponent();
            Players = new List<PlayerStats>();
            SetBindings();

        }

        public void CheckScore(string dificulty, string time)
        {
            int Score = 0;
            if(Dificulty == "2")
            {
                Score = 2 * int.Parse(time);
                Dificulty = "Easy";
            }
            if (Dificulty == "3")
            {
                Score = 3 * int.Parse(time);
                Dificulty = "Moderate";
            }
            if (Dificulty == "4")
            {
                Score = 4 * int.Parse(time);
                Dificulty = "Hard";
            }
            if (Dificulty == "5")
            {
                Score = 5 * int.Parse(time);
                Dificulty = "Explotions!!!";
            }

            LastSlot = Players.Count - 1;
            for(int i = Players.Count - 1; i > Players.Count; i-- )
            {
                string HsTime = Players[i].timeElapsed;
                string DifHs = Players[i].dificulty;
                int HsScore = 0;
                if (DifHs == "Easy")
                {
                    HsScore = 2 * int.Parse(HsTime);
                }
                if (DifHs == "Moderate")
                {
                    HsScore = 3 * int.Parse(HsTime);
                }
                if (DifHs == "Hard")
                {
                    HsScore = 4 * int.Parse(HsTime);
                }
                if (DifHs == "Explotions!!!")
                {
                    HsScore = 5 * int.Parse(HsTime);
                }

                if(Score < HsScore)
                {
                    PlayerName = Prompt.ShowDialog("Player Name", "Please enter you name for a High Score!");
                    Time = time;
                    AddNewHighScore();
                    break;
                }
                else
                {
                    LastSlot--;
                }

            }

        }

        private void AddNewHighScore()
        {
            PlayerStats ps = new PlayerStats();
            ps.playerName = PlayerName;
            ps.dificulty = Dificulty;
            ps.timeElapsed = Time;
            if(LastSlot == Players.Count -1)
            {
                Players.Add(ps);
            }
            else
            {
                Players[LastSlot] = ps;
            }
            HighScoreList.ResetBindings(false);
        }

        private void SetBindings()
        {
            HighScoreList.DataSource = Players;
            listBox1.DataSource = HighScoreList;
            listBox1.DisplayMember = "Display";
            //listBox1.ValueMember = "Display";
            LoadPlayers();
        }

        private void LoadPlayers()
        {
            string path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\" + "/Minesweeper/Resources/HighScore.txt"));
            lines = File.ReadAllLines(path).ToList();
            int HSCount = 1;
            foreach (string line in lines)
            {
                string[] entries = line.Split(',');
                if (entries.Length == 3)
                {
                    PlayerStats ps = new PlayerStats();
                    ps.playerName = entries[0];
                    ps.dificulty = entries[1];
                    ps.timeElapsed = entries[2];
                    Players.Add(ps);
                }
                if (HSCount > 5)
                {
                    break;
                }
                else
                    HSCount++;
            }
            HighScoreList.ResetBindings(false);
        }

        private void SaveList()
        {
            List<string> outputLines = new List<string>();
            foreach (PlayerStats p in Players)
            {
                outputLines.Add(p.playerName + "," + p.dificulty + "," + p.timeElapsed);
            }

            string path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\" + "/Minesweeper/Resources/HighScore.txt"));
            File.WriteAllLines(path, outputLines);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveList();
            Close();
        }
    }

}
