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
        /// Ask the user to enter the number of games he would like to generate
        /// </summary>
           public void AskForGamesNumber()
        {
            Console.WriteLine("Enter the number of Games you would like to start (from 1 to 1000 : ");
        }
        /// <summary>
        /// Ask the user to enter the number of rows
        /// </summary>
        public void AskForGamesToDisplay()
        {
            Console.WriteLine("Enter which games you would like to display (not more than 8) : ");
        }
        /// <summary>
        /// Ask the user to enter the number of rows
        /// </summary>
        /* public int AskForRows()
         {
             while (true)
             {
                 try
                 {
                     Console.WriteLine("Enter the number of Rows from 1 to 20 : ");  

                     int rows = int.Parse(Console.ReadLine());
                     if (rows < 0 || rows > 20)
                     {
                         Console.WriteLine("Please enter the number in the range");
                     }
                     else
                     {
                         return rows;
                     }
                 }
                 catch (Exception e)
                 {
                     Console.WriteLine(e.Message);
                 }
             }*/
        /// <summary>
        /// Ask the user to enter the number of rows
        /// </summary>
        /* public int AskForColumns()
         {
             while (true)
             {
                 try
                 {
                     Console.WriteLine("Enter the number of Columns from 1 to 20 : ");  

                     int columns = int.Parse(Console.ReadLine());
                     if (columns < 0 || columns > 20)
                     {
                         Console.WriteLine("Please enter the number in the range");
                     }
                     else
                     {
                         return columns;
                     }
                 }
                 catch (Exception e)
                 {
                     Console.WriteLine(e.Message);
                 }
             }*/
        public void AskForRows()
        {
            Console.WriteLine("Enter the number of Rows from 1 to 20 : ");  
        }
        public void AskForColumns()
        {
            Console.WriteLine("Enter the number of Columns from 1 to 20 : ");
        }
        /// <summary> 
        /// Ask the user to enter the number of columns 
        /// </summary> 
        /* public int AskForColumns()
         {

               Console.WriteLine("Enter the number of Columns from 1 to 20: ");

             while (true)
             {
                 try
                 {
                     Console.WriteLine("Enter the number of Columns from 1 to 20:");
                     int columns = int.Parse(Console.ReadLine());
                     if (columns < 0 || columns > 20)
                     {
                         Console.WriteLine("Please enter the number in the range");
                     }
                     else
                     {
                         return columns;
                     }
                 }
                 catch (Exception e)
                 {
                     Console.WriteLine(e.Message);
                 }*/



        /// <summary>
        /// Warning if the entered input does not correspond to the requirements
        /// </summary>
        public void WarningOfWrongInput()
        {
            Console.WriteLine("Your input is out of range. try again");
        }
        /// <summary>
        /// Warning if when choosing option for the game, unrecognized command is entered
        /// </summary>
        public void WarningOfWrongCommand()
        {
            Console.WriteLine("Unrecognized command, make another choice");
        }
        /// <summary>
        /// Warning if when choosing option for the game unrecognized command is entered
        /// </summary>
        public void WarningOfNoSavedGame()
        {
          Console.WriteLine("You do not have any games saved, start a new one");  
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
        public void PauseGameOptions()
        {
            Console.WriteLine("To continue the game, press C : ");
            Console.WriteLine("To quit the game, press Q : ");
            Console.WriteLine("To save the game, press S : ");
        }
    }
}
