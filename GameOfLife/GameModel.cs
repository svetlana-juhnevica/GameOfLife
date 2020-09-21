using System;

namespace GameOfLife
{
  //  [Serializable]
   public class GameModel
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public CellStatus[,] Grid { get; set; }
        public int GenerationCount { get; set; }
        public int AliveCellsCount { get; set; }

        /* public GameModel(int rows, int columns, int generationCount, int aliveCellsCount)
         {
             Rows = rows;
             Columns = columns;
             GenerationCount = generationCount;
             AliveCellsCount = aliveCellsCount;
             Grid = new CellStatus[Rows, Columns];  
         }*/
    }
}
