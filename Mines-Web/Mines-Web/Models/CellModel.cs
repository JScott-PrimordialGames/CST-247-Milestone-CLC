using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mines_Web.Models
{
    public class CellModel
    {
        public int Row { get; set; } = -1;
        public int Column { get; set; } = -1;
        public bool Clicked { get; set; } = false;
        public bool Live { get; set; } = false;
        public bool Flagged { get; set; } = false;
        public bool Questionable { get; set; } = false;
        public int LiveNeighbors { get; set; } = 0;

        public CellModel() { }

        public CellModel (int row, int column, bool Live)
        {
            this.Row = row;
            this.Column = column;
            this.Live = Live;
        }

        public CellModel (int row, int column, bool clicked, bool live, bool flagged, bool questionable, int liveNeighbors)
        {
            this.Row = row;
            this.Column = column;
            this.Clicked = clicked;
            this.Live = live;
            this.Flagged = flagged;
            this.Questionable = questionable;
            this.LiveNeighbors = liveNeighbors;
        }
    }
}