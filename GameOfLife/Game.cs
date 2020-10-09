using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace GameOfLife
{
    /// <summary> 
    /// The main class of the game which rnadomly fills the grid with dead and alive cells
    /// and generates the next population
    /// </summary> 
    public class Game
    {
        /// <summary>
        /// Number of rows in the grid
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// Number of columns in the grid
        /// </summary>
        public int Columns { get; set; }

        /// <summary>
        /// The grid with dead and alive cells
        /// </summary>
        public CellStatus[,] Grid { get; set; }

        /// <summary>
        /// Number of generations in the game
        /// </summary>
        public int GenerationCount { get; set; }

        /// <summary>
        /// Number of alive cells in the grid
        /// </summary>
        public int AliveCellsCount { get; set; }

        /// <summary>
        /// Status of the game according to the changing cells in its grid
        /// </summary>
        public bool IsGameAlive { get; set; }

        /// <summary>
        /// New instance for the game
        /// </summary>
        private GameViewer gameViewer = new GameViewer();
       
        public Game(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Grid = new CellStatus[rows, columns];
            Randomize();
        }

        // <summary> 
        /// Randomly fills the grid with dead and alive cells 
        /// </summary> 
        public void Randomize()
        {
            GenerationCount = 0;
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    Grid[row, column] = (CellStatus)RandomNumberGenerator.GetInt32(0, 2);
                    if (Grid[row, column] == CellStatus.Alive)
                    {
                        AliveCellsCount++;
                    }
                }
            }
            GenerationCount++;
        }

        /// <summary> 
        /// Checks the neighbours around the cell, their status and changes it according to the rules 
        /// </summary> 
        public void CalculateNewCellStatus()
        {
            GenerationCount = 1;
            IsGameAlive = false;
            AliveCellsCount = 0;
            var nextGeneration = new CellStatus[Rows, Columns];
            // Loop through every cell  
            for (var row = 1; row < Rows - 1; row++)
            {
                for (var column = 1; column < Columns - 1; column++)
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
                    if (currentCell != nextGeneration[row, column])
                    {
                        IsGameAlive = true;
                    }
                }
            }
            Grid = nextGeneration;
            GenerationCount++;
        }
    }
}








