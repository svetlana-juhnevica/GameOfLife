using System;
using System.Text;

namespace GameOfLife
{ 
    /// <summary> 
    /// Class for displaying on the console. 
    /// </summary> 
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
        /// <summary>
        /// Ask the user to enter the number of rows
        /// </summary>
        public void AskForRows()
        {
            Console.WriteLine("Enter the number of Rows from 1 to 20 : ");
        }
        /// <summary>
        /// Ask the user to enter the number of columns
        /// </summary>
        public void AskForColumns()
        {
            Console.WriteLine("Enter the number of Columns from 1 to 20: ");
        }
        /// <summary>
        /// Warning if number of rows or columns is not an integer from 1 to 20
        /// </summary>
        public void WarningOfWrongInput()
        {
            Console.WriteLine("This is not a valid input. Enter an integer from 1 to 20");
        }
        /// <summary> 
        /// Prints the game to the console with number of generations and alive cells
        /// </summary> 
        public void Print(Game game)
        {
            var stringBuilder = new StringBuilder();
            for (var row = 0; row <game.Rows; row++)
            {
                for (var column = 0; column < game.Columns; column++)
                {
                    var cell = game.Grid[row, column];
                    stringBuilder.Append(cell == CellStatus.Alive ? "A" : ".");
                }
                stringBuilder.Append("\n");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.Write(stringBuilder.ToString());
            Console.WriteLine("Generations: {0}", game.GenerationCount);
            Console.WriteLine("Alive cells: {0}", game.AliveCellsCount);
        }
    }
}
