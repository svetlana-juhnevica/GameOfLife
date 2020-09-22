using System;
using System.Text;

namespace GameOfLife
{
    public class GameViewer
    {
        /// <summary>
        /// Introduction to the Game 
        /// </summary>
        public void PrintGameIntro()
        {
            Console.WriteLine("Welcome to the Game of Life! ");
            Console.WriteLine(" "); //Makes empty space between Intro and selection 
        }
        /// <summary>
        /// Options to choose whether to start a new game, continue the game or quit
        /// </summary>
        public void PrintGameOptions()
        {
            Console.WriteLine("To continue the game, press C : ");
            Console.WriteLine("To quit the game, press Q : ");
            Console.WriteLine("To start a new game, press N : ");
        }
        public GridSize GetGridSize()
        {
            int rows;
            Console.WriteLine("Enter the number of Rows from 1 to 20 : ");
            while (!int.TryParse(Console.ReadLine(), out rows) || rows < 0 || rows > 20)
            {
                Console.WriteLine("This is not a valid input. Enter an integer from 1 to 20");
            }
            int columns;
            Console.WriteLine("Enter the number of Columns from 1 to 20: ");
            while (!int.TryParse(Console.ReadLine(), out columns) || columns < 0 || columns > 20)
            {
                Console.WriteLine("This is not a valid input. Enter an integer from 1 to 20");
            }
            return new GridSize
            {
                Rows = rows,
                Columns = columns
            };
        }
        /// <summary> 
        /// Prints the game to the console. 
        /// </summary>   
        public void Print(GameModel gameModel)
        {
            var Grid = gameModel.Grid;
            int AliveCellsCount = gameModel.AliveCellsCount;
            int GenerationCount = gameModel.GenerationCount;
            int Rows = Grid.GetLength(1);
            int Columns = Grid.GetLength(0);
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    var cell = Grid[row, column];
                    Console.Write(cell == CellStatus.Alive ? "A" : ".");
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
            Console.WriteLine("To quit the game, press Ctrl + C : ");
        }
    }
}
