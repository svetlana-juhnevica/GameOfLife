using System;

namespace GameOfLife
{
   public class GameModel
    {
        readonly int Rows;
        readonly int Columns;
        public CellStatus[,] Grid { get; set; }
        public int GenerationCount { get; set; }
        public int AliveCellsCount { get; set; }
    }
}
