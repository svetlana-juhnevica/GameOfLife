using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class GameModel
    {
        public CellStatus[,] Grid;
        public int GenerationCount;
        public int AliveCellsCount;
    }
}
