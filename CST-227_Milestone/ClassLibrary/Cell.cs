using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Cell
    {
        public int Row { get; set; } = 0;
        public int Column { get; set; } = -1;
        public bool Visited { get; set; } = false;
        public bool Live { get; set; } = false;
        public bool Flagged { get; set; } = false;
        public int LiveNeighbors { get; set; } = 0;

        public Cell(int row, int column, bool visited, bool live, int liveNeighbors)
        {
            Row = row;
            Column = column;
            Visited = visited;
            Live = live;
            LiveNeighbors = liveNeighbors;
        }

        public Cell()
        {

        }

    }
}
