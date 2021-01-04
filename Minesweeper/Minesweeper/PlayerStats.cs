/*

    Joshua Scott
    
    GCU CST-227
    
    This Code is my own work

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public class PlayerStats
    {
        public string playerName { get; set; }
        public string dificulty { get; set; }
        public string timeElapsed { get; set; }

        public string Display
        {
            get
            {
                return string.Format("PlayerName: {0} | Dificulty: {1} | Time: {2}", playerName, dificulty, timeElapsed);
            }
        }
    }
}
