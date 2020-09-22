using System;

namespace GameOfLife
{
   public class GameModel
    {
        public CellStatus[,] Grid { get; set; }
        public int GenerationCount { get; set; }
        public int AliveCellsCount { get; set; }
    }
}
