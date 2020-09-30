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
            Console.WriteLine("To continue the game, press C : ");
            Console.WriteLine("To quit the game, press Q : ");
            Console.WriteLine("To start a new game, press N : ");
        }
         /// <summary>
        /// Ask the user to enter the games to be displayed
        /// </summary>
           public int AskForGamesToDisplay()
        {
            //GameId is the same as the number of the game in its list
            int GameId;
            Console.WriteLine("Enter the number of Games you would like to start (from 1 to 1000 : ");
            while (!int.TryParse(Console.ReadLine(), out GameId) || GameId < 1 || GameId > 1000)
            {
                WarningOfWrongInput();
            }
            return GameId;
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
            Console.WriteLine("To change the games to be displayed, press D : ");

        }
        public void PrintGames(List<Game> games, List<int> selectedGamesId)
      {
         Console.Clear();
         foreach (int index in selectedGamesId)
            {
                Game game = games[index - 1];
                Print(game);
            }             
         //  Console.WriteLine("Alive games count: {0}", aliveGameCount);
                         }

        }
    }

