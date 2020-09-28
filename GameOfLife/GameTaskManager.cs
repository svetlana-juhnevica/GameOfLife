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
        private Game game;
        private GameViewer gameViewer;
        private GameFileSaver gameFileSaver;
        private List<Game> games;
        //  private List<int> printedGames;
        public static Timer timer;
        public int GamesNumber;
        ConsoleKeyInfo cki;

        public GameTaskManager()
        {
            games = new List<Game>();
            game = new Game();
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
                string input = Console.ReadLine().ToLower();
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

            game.RandomFillByChosenGridSize();
            // Establish an event handler to process key press events.
            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);
            StartTimer();

        } 

            

           
       private void myHandler(object sender, ConsoleCancelEventArgs args)
            {
                // Set the Cancel property to true to prevent the process from terminating.

                args.Cancel = true;
                timer.Enabled = false;
                gameViewer.PauseGameOptions();
                
            }
          //  timer.Enabled = false;
          //  Console.WriteLine("The game is over");
         //   Environment.Exit(0);
        

            public void StartTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            game.CalculateNewCellStatus();
            gameViewer.Print(game);
            gameFileSaver.SaveGame(game);
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
        /// To generate games according to the user's chosen number of games
        /// </summary>
        public void GenerateGames()
        { 
            gameViewer.AskForGamesNumber();
            while (!int.TryParse(Console.ReadLine(), out GamesNumber) || GamesNumber < 0 || GamesNumber > 1000)
            {
                gameViewer.WarningOfWrongInput();
            }
            for (int g = 0; g < GamesNumber; g++)
            {
                game.RandomFillByChosenGridSize();
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
    }
}

