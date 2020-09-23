using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace GameOfLife
{

    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;

    namespace GameOfLife
    {
        public class Game
        {
            public int Rows;
            public int Columns;
            public CellStatus[,] Grid;
            public int GenerationCount;
            public int AliveCellsCount;
            private GameViewer GameViewer;
            //  private GameModel GameModel;

            public Game()
            {
                GameViewer = new GameViewer();
                // GameModel = new GameModel();
            }

            /// <summary> 
            /// Randomly fills the grid according to user's choice of grid size 
            /// </summary> 
            public void RandomFillByChosenGridSize()
            {
                Console.WriteLine("Enter the number of Rows from 1 to 20 : ");
                while (!int.TryParse(Console.ReadLine(), out Rows) || Rows < 0 || Rows > 20)
                {
                    Console.WriteLine("This is not a valid input. Enter an integer from 1 to 20");
                }

                Console.WriteLine("Enter the number of Columns from 1 to 20: ");
                while (!int.TryParse(Console.ReadLine(), out Columns) || Columns < 0 || Columns > 20)
                {
                    Console.WriteLine("This is not a valid input. Enter an integer from 1 to 20");
                }

                Grid = new CellStatus[Rows, Columns];
                GenerationCount = 1;
                AliveCellsCount = 0;
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
                //  Console.Clear(); 
            }

            /// <summary> 
            /// Checks the neighbours around the cell, their status and changes it according to the rules 
            /// </summary> 
            public void CalculateNewCellStatus(int timeout =1000)
            {
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
                var stringBuilder = new StringBuilder();
                for (var row = 0; row < Rows; row++)
                {
                    for (var column = 0; column < Columns; column++)
                    {
                        var cell = Grid[row, column];
                        stringBuilder.Append(cell == CellStatus.Alive ? "A" : ".");
                    }
                    stringBuilder.Append("\n");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                Console.Clear();
                Console.Write(stringBuilder.ToString());
                Console.WriteLine("Generations: {0}", GenerationCount);
                Console.WriteLine("Alive cells: {0}", AliveCellsCount);
            }
        }
    }
}

/*    //Console.Clear();
            Console.SetCursorPosition(0, 0);
            // AliveCellsCount = 0;
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    var cell = this.Grid[row, column];
                    Console.Write(cell == CellStatus.Alive ? "A" : ".");
                    // if (Grid[row, column] == CellStatus.Alive)
                    //{
                    //  AliveCellsCount++;
                    //}
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine("Generations: {0}", GenerationCount);
            Console.WriteLine("AliveCells: {0}", AliveCellsCount);
            Console.WriteLine(" ");// to make spacing between the game and choice of actions
            Console.WriteLine("To quit the game, press Ctrl + C : ");*/


