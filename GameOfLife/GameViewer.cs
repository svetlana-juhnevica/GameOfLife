using System;
using System.Collections.Generic;
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
            Console.WriteLine("To start a new game, press 1: ");
            Console.WriteLine("To load the previous game, press 2 : ");
            Console.WriteLine("To quit the game, press 3 : ");
            
        }
         /// <summary>
        /// Ask the user to enter the games to be displayed
        /// </summary>
           public int AskForGamesToDisplay()
        {
            int gameNumber;
            Console.WriteLine("Enter the number of Games you would like to display (from 1 to 1000). You can choose 8 games in total : ");
            while (!int.TryParse(Console.ReadLine(), out gameNumber) || gameNumber < 1 || gameNumber > 1000)
            {
                WarningOfWrongInput();
            }
            return gameNumber;
        }
       
        /// <summary>
        /// Ask the user to enter the number of rows
        /// </summary>
        public int AskForRows()
        {
            int Rows;
            Console.WriteLine("Enter the number of Rows from 1 to 20 : ");

            while (!int.TryParse(Console.ReadLine(), out Rows) || Rows < 0 || Rows > 20)
            {
               WarningOfWrongInput();
            }
            return Rows;
        }
        /// <summary>
        /// Ask the user to enter the number of columns
        /// </summary>
        public int AskForColumns()
        {
           Console.WriteLine("Enter the number of Columns from 1 to 20 : ");
           int Columns;
            while (!int.TryParse(Console.ReadLine(), out Columns) || Columns < 0 || Columns > 20)
            {
                WarningOfWrongInput();
            }
            return Columns;
        }
     
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
           // Console.SetCursorPosition(0, 0);
           // Console.Clear();
            Console.Write(stringBuilder.ToString());
            Console.WriteLine("Generations: {0}", game.GenerationCount);
            Console.WriteLine("Alive cells: {0}", game.AliveCellsCount);
        }
        /// <summary>
        /// Options for the game when paused
        /// </summary>
        public void PauseGameOptions()
        {
            Console.WriteLine("To continue the game, press C: ");
            Console.WriteLine("To change the games to be displayed, press N : ");
            Console.WriteLine("To save the game, press S : ");
            Console.WriteLine("To quit the game, press Q: ");
        }
        public void PrintGames(List<Game> games, List<int> selectedGamesId)
        {   
         foreach (int index in selectedGamesId)
            {   Console.WriteLine("Game: {0}", index);
                Game game = games[index - 1];
                Print(game);
            }             
         //  Console.WriteLine("Alive games count: {0}", aliveGameCount);
                         }

        }
    }

