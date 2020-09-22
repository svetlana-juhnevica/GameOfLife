using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace GameOfLife
{
    public class CellStatusCalculator
    {
        private GridSize gridSize;
        private CellStatus[,] Grid;
        public int GenerationCount { get; set; }
        public int AliveCellsCount { get; set; }

        public CellStatusCalculator(GameModel gameModel)
        {
            GenerationCount = gameModel.GenerationCount;
            AliveCellsCount = gameModel.AliveCellsCount;
            Grid = gameModel.Grid;
        }
        /// <summary>
        /// Randomly fills the grid according to user's choice of grid size
        /// </summary>
        public void RandomFillByChosenGridSize()
        {
            var Grid = new CellStatus[gridSize.Rows, gridSize.Columns];
            GenerationCount = 1;
            AliveCellsCount = 0;
            for (var row = 0; row < gridSize.Rows; row++)
            {
                for (var column = 0; column < gridSize.Columns; column++)
                {
                    Grid[row, column] = (CellStatus)RandomNumberGenerator.GetInt32(0, 2);
                    if (Grid[row, column] == CellStatus.Alive)
                    {
                        AliveCellsCount++;
                    }
                }
            }
        }

        /// <summary>
        /// Checks the neighbours around the cell, their status and changes it according to the rules
        /// </summary>
        public void CalculateNewCellStatus()
        {
            AliveCellsCount = 0;
            var nextGeneration = new CellStatus[gridSize.Rows, gridSize.Columns];
            // Loop through every cell 
            for (var row = 1; row < gridSize.Rows - 1; row++)
            {
                for (var column = 1; column < gridSize.Columns - 1; column++)
                {
                    if (Grid[row, column] == CellStatus.Alive)
                    {
                        AliveCellsCount++;
                    }
                    // Find the alive neighbors
                    var aliveNeighbors = 0;
                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            aliveNeighbors += Grid[row + i, column + j] == CellStatus.Alive ? 1 : 0;
                        }
                    }
                    var currentCell = Grid[row, column];

                    // Subtract the current cell from the neighbor count
                    aliveNeighbors -= currentCell == CellStatus.Alive ? 1 : 0;

                    // Following the Rules of Life 

                    // Cell is lonely and dies 
                    if (currentCell == CellStatus.Alive && aliveNeighbors < 2)
                    {
                        nextGeneration[row, column] = CellStatus.Dead;
                    }

                    // Cell dies due to over population 
                    else if (currentCell == CellStatus.Alive && aliveNeighbors > 3)
                    {
                        nextGeneration[row, column] = CellStatus.Dead;
                    }

                    // A new cell is born 
                    else if (currentCell == CellStatus.Dead && aliveNeighbors == 3)
                    {
                        nextGeneration[row, column] = CellStatus.Alive;
                    }

                    // All other cells stay the same
                    else
                    {
                        nextGeneration[row, column] = currentCell;
                    }
                }
            }
            Grid = nextGeneration;
            GenerationCount++;
        }
    }
}
