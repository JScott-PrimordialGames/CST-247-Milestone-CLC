using ClassLibrary;
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
    public partial class Form1 : Form
    {
        public static List<PlayerStats> highScores = new List<PlayerStats>();
        public static string path = "";
        public Form1()
        {
            InitializeComponent();

            path = Directory.GetCurrentDirectory() + "\\HighScores.txt";

            if (!File.Exists(path))
            {
                string randomScores = "Bob|1|0|0\nTony|1|0|0\nKimbo|1|0|0\nEmily|1|0|0\nChris|1|0|0";
                File.WriteAllText(path, randomScores);
            }
        }

        private void btn_startGame_Click(object sender, EventArgs e)
        {
            string difficulty = "";
            int size = 0;
            bool selectedDifficulty = false;

            // What difficulty did the user select?
            foreach (RadioButton r in groupBox_DifficultySelection.Controls)
            {
                if (r.Checked)
                {
                    difficulty = r.Text;
                    selectedDifficulty = true;
                }
            }

            if (selectedDifficulty == true)
            {
                switch (difficulty)
                {
                    case "Easy":
                        size = 10;
                        break;

                    case "Moderate":
                        size = 15;
                        break;

                    case "Difficult":
                        size = 20;
                        break;

                    default:
                        break;

                }
                Form_Game form = new Form_Game(size, path);
                form.Show();
            }
        }
    }
}
