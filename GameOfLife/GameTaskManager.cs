using System;
using System.Collections.Generic;
using System.Timers;

namespace GameOfLife
{
    /// <summary> 
    /// Class for managing tasks:start a new game, continue or exit. 
    /// </summary>
    public class GameTaskManager
    {
       // private Game game;
        private GameViewer gameViewer;
        private GameFileSaver gameFileSaver;
        public List<Game> games;
        public List<int> selectedGamesNumber;
        public static Timer timer;
        
        ConsoleKeyInfo cki;

        public GameTaskManager()
        {
            games = new List<Game>();
            selectedGamesNumber = new List<int>();
            gameViewer = new GameViewer();
            gameFileSaver = new GameFileSaver();
        }
        /// <summary>
        /// The game starts with introduction and options to choose the game task
        /// </summary>
        public void StartGame()
        {
            gameViewer.PrintGameIntro();
            gameViewer.PrintGameOptions();

            /// User makes choice: to continue, quit or start a new game 
            while (true)
            {
                string input = Console.ReadLine()?.ToLower();
                //if not any key pressed, returns to the while loop
                if (input == null)
                {
                    continue;
                }
                switch (input)
                {
                    //if "quit" is pressed 
                    case "q":
                        Environment.Exit(0);
                        break;

                    //if "start a new game" is pressed 
                    case "n":
                        NewGame();
                        break;

                    // if "continue the game" is pressed 
                    case "c":
                        ContinueGame();
                        break;

                    // if unknown command is pressed 
                    default:
                        gameViewer.WarningOfWrongCommand();
                        break;
                }
            }
        }

        /// <summary> 
        /// A new game undergoes the full cycle 
        /// </summary> 
        public void NewGame()
        {
           GenerateGames();
           GamesForDisplaying();
           // game.RandomFillByChosenGridSize();
            // Establish an event handler to process key press events.
            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);
            StartTimer();

        } 
        /// <summary>
        /// Set the Cancel property to true to prevent the process from terminating.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
  
       private void myHandler(object sender, ConsoleCancelEventArgs args)
            {
                args.Cancel = true;
                timer.Enabled = false;
                gameViewer.PauseGameOptions();
                
            }
          /// <summary>
          /// Timer for each iteration to be updated in 1 second
          /// </summary>
            public void StartTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        /// <summary>
        /// Timer event handler
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            // game.CalculateNewCellStatus();
            //  gameViewer.Print(game);
           //   gameFileSaver.SaveGame(game);
               CalculateGamesNewCellStatus();
               gameViewer.PrintGames(games, selectedGamesNumber);
             //  gameFileSaver.SaveGames(games);
        }
        /// <summary> 
        /// A saved game continues to the next cycle 
        /// </summary> 
        public void ContinueGame()
        {
            var game = gameFileSaver.LoadGame();
            if (game == null)
            {
                gameViewer.WarningOfNoSavedGame();
                NewGame();
            }
            StartTimer();
            do
            {
                while (!Console.KeyAvailable)
                {
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            timer.Enabled = false;
            Environment.Exit(0);
        }
        /// <summary>
        ///  Generates 1000 games according to the user's chosen gridsize
        /// </summary>
        public void GenerateGames()
        {
          int  rows = gameViewer.AskForRows();
          int columns = gameViewer.AskForColumns();
            for (int g = 0; g < 1000; g++)
            {
                Game game = new Game(rows, columns);
                game.Randomize();
                games.Add(game);
            }
        }
        /// <summary>
        /// Calculates next generation grid for generated games
        /// </summary>
        public void CalculateGamesNewCellStatus()
        {
            foreach (Game game in games)
            {
                game.CalculateNewCellStatus();
            }
        }
        /// <summary>
        /// Makes list of games numbers for displaying
        /// </summary>
        private void GamesForDisplaying()
         { 
            for(int i = 0; i<8; i++)
            {
                int number = gameViewer.AskForGamesToDisplay();
                selectedGamesNumber.Add(number);
            }
        }
       

}
}

