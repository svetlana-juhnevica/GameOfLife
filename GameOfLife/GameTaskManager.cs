using System;
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
            public static Timer timer;
            public GameTaskManager()
            {
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
                            Console.WriteLine("Unrecognized command, make another choice");
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

                ///The Game is running until Ctrl + C is pressed 
                do
                { 
                    while (!Console.KeyAvailable)
                    {
                      // StartTimer(); 
                        gameViewer.Print(game);
                        game.CalculateNewCellStatus();
                        gameFileSaver.SaveGame(game);
                    }
                    
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                timer.Enabled = false; 
                Console.WriteLine("The game is over");
                Environment.Exit(0);
            }
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
               // game.Print();
                gameFileSaver.SaveGame(game);
            }

        /// <summary> 
        /// A saved game continues to the next cycle 
        /// </summary> 
        public void ContinueGame()
            {
                var game= gameFileSaver.LoadGame();
                if (game == null)
                {
                Console.WriteLine("You do not have any games saved, start a new one");
                    NewGame();
                }
                do
                {
                    while (!Console.KeyAvailable)
                    {
                       // StartTimer();
                       gameViewer.Print(game);
                       game.CalculateNewCellStatus();
                       gameFileSaver.SaveGame(game);
                     }

                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                timer.Enabled = false;
                Console.WriteLine("The game is over");
                Environment.Exit(0);
            }
        }
    }

