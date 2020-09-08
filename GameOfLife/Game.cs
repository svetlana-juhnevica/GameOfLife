using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Threading;

namespace GameOfLife
{
    public class Game
    {
        public int Rows;
        public int Columns;
        public Cell[,] Grid;
        int GenerationCount=0;

        public Game(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Grid = new Cell[Rows, Columns];
            RandomFill();
        }

        public enum Cell
        {
            Dead,
            Alive,
        }
       
        public void RandomFill()
        {
            
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    Grid[row, column] = (Cell)RandomNumberGenerator.GetInt32(0, 2);
                }

            }
           
        }

       


        public void Calculate()
        {
            //GenerationCount++;
            var nextGeneration = new Cell[Rows, Columns];
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
                            aliveNeighbors += Grid[row + i, column + j] == Cell.Alive ? 1 : 0;
                        }
                    }

                    var currentCell = Grid[row, column];

                    // Subtract the current cell from the neighbor count
                    aliveNeighbors -= currentCell == Cell.Alive ? 1 : 0;

                    // Following the Rules of Life 

                    // Cell is lonely and dies 
                    if (currentCell == Cell.Alive && aliveNeighbors < 2)
                    {
                        nextGeneration[row, column] = Cell.Dead;
                    }

                    // Cell dies due to over population 
                    else if (currentCell == Cell.Alive && aliveNeighbors > 3)
                    {
                        nextGeneration[row, column] = Cell.Dead;
                    }

                    // A new cell is born 
                    else if (currentCell == Cell.Dead && aliveNeighbors == 3)
                    {
                        nextGeneration[row, column] = Cell.Alive;
                    }

                    // All other cells stay the same
                    else
                    {
                        nextGeneration[row, column] = currentCell;
                    }
                }
            }
            Grid = nextGeneration;
            //Console.WriteLine("Generations: {0}", GenerationCount);
        }

        // Count the number of alive cells
        public void AliveCellsCount()
        {
            int AliveCellsCount = 0;
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    if (Grid[row, column] == Cell.Alive)
                    {
                        AliveCellsCount++;
                    }

                }
            }
            Console.WriteLine("Alive cells: {0}", AliveCellsCount);
        }
        /// Prints the game to the console.
        public void Print(int timeout = 1000)
        {
            GenerationCount++;
            var stringBuilder = new StringBuilder();

            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    var cell = this.Grid[row, column];
                    stringBuilder.Append(cell == Cell.Alive ? "A" : "D");
                }
                    stringBuilder.Append("\n");

                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                Console.Write(stringBuilder.ToString());
                Console.WriteLine("Generations: {0}", GenerationCount);
                Thread.Sleep(timeout);

            }
        }
    }

    
  
      
    
