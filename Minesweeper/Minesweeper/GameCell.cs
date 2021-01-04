/*

    Joshua Scott
    
    GCU CST-227
    
    This Code is my own work

*/
using MilestoneProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public class GameCell : Button
    {
        public int row { get; set; }
        public int col { get; set; }
        public bool visited { get; set; }
        public bool live { get; set; }
        public int liveNeighbors { get; set; }
        public int count { get; set; }

        public PlayScreen parent { get; set; }


        public GameCell()
        {
            this.row = -1;
            this.col = -1;
            this.visited = false;
            this.live = false;
            this.liveNeighbors = 0;
            this.count = 0;
            this.BackColor = System.Drawing.Color.Aqua;
            this.Padding = new Padding(15, 15, 15, 15);
            this.Enabled = true;
            this.parent = null;
            this.Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 6.0f);
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            switch(e.Button)
            {
                case MouseButtons.Right:
                    {
                        this.visited = true;
                        this.BackColor = System.Drawing.Color.LightGray;
                        this.Image = Properties.Resources.Flag;
                        break;
                    }
                case MouseButtons.Left:
                    {
                        if(!live)
                        {
                            this.BackColor = System.Drawing.Color.LightGray;
                            this.Text = liveNeighbors.ToString();
                            Cell ThisCell = parent.gameBoard.GameBoard.Find(cell => cell.Column == this.col && cell.Row == this.row);
                            ThisCell.Visited = true;
                            parent.checkedCells++;
                            if (liveNeighbors == 0 || liveNeighbors == 10)
                            {
                                parent.ShowZeros(this.row, this.col);
                            }
                            if (parent.checkedCells == parent.checkedCellsCounter)
                                parent.Victory();
                        }
                        else if (live)
                        {
                            this.visited = true;
                            this.BackColor = System.Drawing.Color.LightGray;
                            this.Image = Properties.Resources.bomb;
                            parent.BombHit();
                        }
                        break;
                    }
            }
        }

        public void ZeroReveal()
        {
            if (!visited)
            {
                parent.checkedCells++;
                this.visited = true;
                this.BackColor = System.Drawing.Color.LightGray;
                if (liveNeighbors == 10)
                    this.Text = "0";
                else
                    this.Text = liveNeighbors.ToString();
            }
        }
    }
}
