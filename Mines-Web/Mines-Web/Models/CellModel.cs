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
        public bool Visited { get; set; } = false;
        public bool Live { get; set; } = false;
        public bool Flagged { get; set; } = false;
        public bool Questionable { get; set; } = false;
        public int LiveNeighbors { get; set; } = 0;

        public CellModel() { }

        public CellModel (int column, int row, bool Live)
        {
            this.Row = row;
            this.Column = column;
            this.Live = Live;
        }

        public CellModel(int column, int row)
        {
            this.Row = row;
            this.Column = column;
            this.Live = false;
        }

        public CellModel (int row, int column, bool visited, bool live, bool flagged, bool questionable, int liveNeighbors)
        {
            this.Row = row;
            this.Column = column;
            this.Visited = visited;
            this.Live = live;
            this.Flagged = flagged;
            this.Questionable = questionable;
            this.LiveNeighbors = liveNeighbors;
        }
    }
}