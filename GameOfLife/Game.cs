using System;
using System.Security.Cryptography;
using System.Threading;

    namespace GameOfLife
    {
        /// <summary> 
        /// The main class of the game which rnadomly fills the grid with dead and alive cells
        /// and generates the next population
        /// </summary> 
        public class Game
        {
            public int Rows;
            public int Columns;
            public CellStatus[,] Grid;
            public int GenerationCount;
            public int AliveCellsCount;
            private GameViewer gameViewer;

            public Game()
            {
                gameViewer = new GameViewer();
            }

            /// <summary> 
            /// Randomly fills the grid according to user's choice of grid size 
            /// </summary> 
            public void RandomFillByChosenGridSize()
            {
                gameViewer.AskForRows();
                while (!int.TryParse(Console.ReadLine(), out Rows) || Rows < 0 || Rows > 20)
                {
                    gameViewer.WarningOfWrongInput();
                }
                gameViewer.AskForColumns();
                while (!int.TryParse(Console.ReadLine(), out Columns) || Columns < 0 || Columns > 20)
                {
                    gameViewer.WarningOfWrongInput();
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
            }

            /// <summary> 
            /// Checks the neighbours around the cell, their status and changes it according to the rules 
            /// </summary> 
            public void CalculateNewCellStatus()
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
                
            }
        }
    }


