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
        // public static int GenerationCount;
        public Cell[,] Grid;
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

        /* public int GenerationCount
         {
             get { return generationCount; }

         }
        */
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
        }



        /// Prints the game to the console.
        public void Print (int timeout = 1000)
          {
              var stringBuilder = new StringBuilder();
              for (var row = 0; row < Rows; row++)
              {
                  for (var column = 0; column < Columns; column++)
                  {
                      var cell = this.Grid[row, column];
                      stringBuilder.Append(cell == Cell.Alive ? "D" : "A");
                  }
                  stringBuilder.Append("\n");

              }
        
       /* public void Print()
        { 
            for (int row = 0; row<Rows; row++) { 
               for (int column = 0; column<Columns; column++) { 
                    Console.Write(Grid[row, column] ? "x" : " "); 
                   if (column == Columns - 1) Console.WriteLine("\r"); 
                } 
            }
            Console.SetCursorPosition(0, Console.WindowTop);
        
        */

           Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Write(stringBuilder.ToString());
            Thread.Sleep(timeout);

        }
    }
}
    
  
      
    
