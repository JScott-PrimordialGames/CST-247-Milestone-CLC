/*

    Joshua Scott
    
    GCU CST-227
    
    This Code is my own work

*/
using System;
using System.Collections.Generic;
using System.Text;

namespace MilestoneProject
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Visited { get; set; }
        public bool Live { get; set; }
        public int LiveNeighbors { get; set; }

        public Cell(int row, int column, bool visited, bool live, int liveNeighbors)
        {
            Column = column;
            Row = row;
            Visited = visited;
            Live = live;
            LiveNeighbors = liveNeighbors;

        }

        public Cell()
        {
            Row = -1;
            Column = -1;
            Visited = false;
            Live = false;
            LiveNeighbors = 0;
        }
    }

}
