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
        private GameViewer gameViewer = new GameViewer();
        private GameFileSaver gameFileSaver = new GameFileSaver();
        private List<Game> games = new List<Game>();
        private List<int> selectedGamesNumber = new List<int>();
        private Timer timer;
        /// <summary> 
        /// The status of the game whether the game is running. 
        /// </summary> 
        public bool Running;
        /// <summary>
        /// Number of all alive games
        /// </summary>
        private int aliveGamesCount;
        /// <summary>
        /// Number of all alive cells in the game
        /// </summary>
        private int totalAliveCellsCount;
        /// <summary>
        /// Number of generated games
        /// </summary>
        public int gamesCount;
        /// <summary>
        /// Ordinal Number of the game to be displayed
        /// </summary>
        public int gameNumber;
        /// <summary>
        /// Number of games to be displayed
        /// </summary>
        public int displayedGamesCount;
       
        /// <summary> 
        /// Run game. 
        /// </summary> 
        public void Run()
        {
            Running = true;

            StartGame();

            while (Running)
            {
                System.Threading.Thread.Sleep(1000);
            }
        }


        /// <summary>
        /// The game starts with introduction and options to choose the game task
        /// </summary>
        public void StartGame()
        {
            gameViewer.PrintGameIntro();
            GameMenu command = gameViewer.PrintGameOptions();
                    
            /// User makes choice: to continue, quit or start a new game 
             switch (command)
            {
                // if "start the game" is pressed  
                case GameMenu.NewGame:
                    NewGame();
                    break;
                // if "continue the game" is pressed  
                case GameMenu.ContinueGame:
                    ContinueGame();
                    break;
                //if "save the game" is pressed  
                case GameMenu.SaveGame:
                    gameFileSaver.SaveGames(games);
                    PauseGame();
                    break;
                //if "quit the game" is pressed  
                case GameMenu.Exit:
                   Environment.Exit(0);
                    break;
                // if unknown command is pressed  
                default:
                    gameViewer.WarningOfWrongCommand();
                    break;
            }
        }

        /// <summary> 
        /// A new game undergoes the full cycle 
        /// </summary> 
        public void NewGame()
        {
            GenerateGames();
            GamesForDisplaying();

            /// Establish an event handler to process key press events.
            gameViewer.GamePaused += Pause;
            StartTimer();
        }

        /// <summary>
        /// Set the Cancel property to true to prevent the process from terminating.
        /// </summary> 
        private void Pause()
        {
            timer.Elapsed -= OnTimedEvent;
            gameViewer.GamePaused -= Pause;
            timer.Enabled = false;
            PauseGame();
        }

        /// <summary>
        /// User makes choice what to do when the game is paused
        /// </summary>
        public void PauseGame()
        {
            PausedGameMenu input = gameViewer.PauseGameOptions();
            
            switch (input)
            {
                // if "continue the game" is pressed  
                case PausedGameMenu.ContinuePausedGame:
                    ContinuePausedGame();
                    break;
                //if "change the games to be displayed" is pressed  
                case PausedGameMenu.ChangeGamesForDisplaying:
                    ChangeGamesForDisplaying();
                    break;
                //if "save" is pressed  
                case PausedGameMenu.SaveGame:
                    gameFileSaver.SaveGames(games);
                    PauseGame();
                    break;
                //if "continue saved game" is pressed  
                case PausedGameMenu.ContinueSavedGame:
                    ContinueGame();
                    break;
                //if "quit" is pressed  
                case PausedGameMenu.Exit:
                    Environment.Exit(0);
                    Running = false;
                    break;
                // if unknown command is pressed  
                default:
                    gameViewer.WarningOfWrongCommand();
                    break;
            }
        }

        /// <summary> 
        /// Continues previous game after pause. 
        /// </summary> 
        private void ContinuePausedGame()
        {
            gameViewer.GamePaused += Pause;
            StartTimer();
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
        }

        /// <summary> 
        /// A loaded game continues to the next cycle 
        /// </summary> 
        public void ContinueGame()
        {
            var games = gameFileSaver.LoadGames();
            if (games == null)
            {
                gameViewer.WarningOfNoSavedGame();
                NewGame();
            }
            GamesForDisplaying();
            gameViewer.GamePaused += Pause;
            StartTimer();
        }

        /// <summary>
        ///  Generates games according to the user's chosen gridsize and count of games
        /// </summary>
        public void GenerateGames()
        {
            gamesCount = gameViewer.AskForGamesCount();
            int rows = gameViewer.AskForRows();
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
            displayedGamesCount = gameViewer.AskForDisplayedGamesCount();
            for (int i = 0; i < displayedGamesCount; i++)
            {
                int number = gameViewer.AskForGamesToDisplay();
                selectedGamesNumber.Add(number);
            }
        }

        /// <summary>
        /// The user changes the games to be displayed
        /// </summary>
        private void ChangeGamesForDisplaying()
        {
            GamesForDisplaying();
            gameViewer.GamePaused += Pause;
            StartTimer();
        }
    }
}

