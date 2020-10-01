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
        private GameViewer gameViewer;
        private GameFileSaver gameFileSaver;
        public List<Game> games;
        public List<int> selectedGamesNumber;
        public static Timer timer;
        ConsoleKeyInfo cki;
        private int aliveGamesCount; 
        private int totalAliveCellsCount;
        public int gamesCount;


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
                /* string input = Console.ReadLine()?.ToLower();
                 //if not any key pressed, returns to the while loop 
                 if (input == null)
                 {
                     continue;
                 }*/
              int  input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        // if "start the game" is pressed  
                        case 1:
                            NewGame();
                            break;
                        // if "continue the game" is pressed  
                        case 2:
                            ContinueGame();
                            break;
                        //if "quit" is pressed  
                        case 3:
                        gameFileSaver.SaveGames(games);
                        Environment.Exit(0);
                            break;
                  /*  //if "change the games to be displayed" is pressed  
                    case "d":
                        ChangeGamesForDisplaying();
                        break;*/

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

            // Establish an event handler to process key press events.
            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);
            while (true)
            {
                StartTimer();
            }
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
               // timer.Elapsed -= OnTimedEvent;
                PauseGame();
            }
        public void PauseGame()
        {
            gameViewer.PauseGameOptions();
            while (true)
            {
                /* string input = Console.ReadLine()?.ToLower();
                 //if not any key pressed, returns to the while loop 
                 if (input == null)
                 {
                     continue;
                 }*/
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                   // if "continue the game" is pressed  
                    case 1:
                        ContinueGame();
                        break;
                  //if "change the games to be displayed" is pressed  
                    case 2:
                       ChangeGamesForDisplaying();
                        break;
                    //if "save" is pressed  
                    case 3:
                        gameFileSaver.SaveGames(games);
                        break;
                    //if "quit" is pressed  
                    case 4:
                        Environment.Exit(0);
                        break;
                    
                    // if unknown command is pressed  
                    default:
                        gameViewer.WarningOfWrongCommand();
                        break;
                }
            }
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
               CalculateGamesNewCellStatus();
               gameViewer.PrintGames(games, selectedGamesNumber, aliveGamesCount, totalAliveCellsCount);
               gameFileSaver.SaveGames(games);
        }
        /// <summary> 
        /// A loaded game continues to the next cycle 
        /// </summary> 
        public void ContinueGame()
        {
            var game = gameFileSaver.LoadGame();
            if (game == null)
            {
                gameViewer.WarningOfNoSavedGame();
                NewGame();
            }
            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);
            while (true)
            {
                StartTimer();
            }
        }
        /// <summary>
        ///  Generates games according to the user's chosen gridsize and count of games
        /// </summary>
        public void GenerateGames()
        {
          gamesCount = gameViewer.AskForGamesCount();
          int  rows = gameViewer.AskForRows();
          int columns = gameViewer.AskForColumns();
            for (int g = 0; g < gamesCount; g++)
            {
                Game game = new Game(rows, columns);
                game.Randomize();
                games.Add(game);
                totalAliveCellsCount += game.AliveCellsCount;
            }
        }
        /// <summary>
        /// Calculates next generation grid for generated games
        /// </summary>
        public void CalculateGamesNewCellStatus()
        {
            totalAliveCellsCount = 0;
            aliveGamesCount = 0;
            foreach (Game game in games)
            {
                game.CalculateNewCellStatus();
                totalAliveCellsCount += game.AliveCellsCount;
                if (game.IsGameAlive)
                {
                    aliveGamesCount++;
                }
            }
        }
        /// <summary>
        /// Makes list of games numbers for displaying
        /// </summary>
        private void GamesForDisplaying()
         { 
            for(int i = 0; i< 8; i++)
            {
                int number = gameViewer.AskForGamesToDisplay();
                selectedGamesNumber.Add(number);
            }
        }
        private void ChangeGamesForDisplaying()
        {
            GamesForDisplaying();
            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);
            StartTimer();    
        }


    }
}

