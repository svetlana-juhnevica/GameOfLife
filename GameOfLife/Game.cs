using System;
using System.Text;
using System.Security.Cryptography;
using System.Threading;

namespace GameOfLife
{
    public class Game
    {
        public int Rows;
        public int Columns;
        public CellStatus[,] Grid;
        public int GenerationCount = 0;
        public int AliveCellsCount;

        ///Constructor for Game
        public Game(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Grid = new CellStatus[Rows, Columns];
           //RandomFill();
        }

        /// <summary>
        /// Randomly fills the grid
        /// </summary>
        public void RandomFill()
        {
            GenerationCount = 1;
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    Grid[row, column] = (CellStatus)RandomNumberGenerator.GetInt32(0, 2);
                }   
            }
            Console.Clear();
        }

        /// <summary>
        /// Checks the neighbours around the cell, their status and changes it according to the rules
        /// </summary>
        public void CalculateNewCellStatus(int timeout = 1000)
        { 
            var nextGeneration = new CellStatus[Rows, Columns];
            // Loop through every cell 
            for (var row = 1; row < Rows - 1; row++)
            {
               for (var column = 1; column < Columns - 1; column++)
                {
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
            Thread.Sleep(timeout);
        }

         /// <summary>
        /// Prints the game to the console.
        /// </summary>  
        public void Print()
        {
            AliveCellsCount = 0;
            var stringBuilder = new StringBuilder();
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    var cell = this.Grid[row, column];
                    stringBuilder.Append(cell == CellStatus.Alive ? "A" : ".");
                    if (Grid[row, column] == CellStatus.Alive)
                    {
                        AliveCellsCount++;
                    }
                }
                stringBuilder.Append("\n");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.Write(stringBuilder.ToString());
            Console.WriteLine("Generations: {0}", GenerationCount);
            Console.WriteLine("AliveCells: {0}", AliveCellsCount);
        }
    }
}

    
  
      
    
