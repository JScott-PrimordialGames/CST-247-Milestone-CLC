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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void BTN_Play_Click(object sender, EventArgs e)
        {
            if(RB_Easy.Checked)
            {
                PlayScreen game = new PlayScreen(2);
                game.Show();
            }
            else if(RB_Moderate.Checked)
            {
                PlayScreen game = new PlayScreen(3);
                game.Show();
            }
            else if(RB_Hard.Checked)
            {
                PlayScreen game = new PlayScreen(4);
                game.Show();
            }
            else if(RB_Explotion.Checked)
            {
                PlayScreen game = new PlayScreen(5);
                game.Show();
            }
        }

        private void BTN_MMHighScore_Click(object sender, EventArgs e)
        {
            HighScore hs = new HighScore();
            hs.Show();
        }
    }
}
