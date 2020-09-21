using System;
using System.Timers;

namespace GameOfLife
{
    public class GameTaskManager
    {
        private GameTasks GameTasks;
        private GameViewer GameViewer;
        private GameModel GameModel;
        private GameFileSaver GameFileSaver;
        public static Timer timer;
        public GameTaskManager()
        {
            GameTasks = new GameTasks();
            GameViewer = new GameViewer();
            GameModel = new GameModel();
            GameFileSaver = new GameFileSaver();
        }
        /// <summary>
        /// The game starts with introduction and options to choose the game task
        /// </summary>
        public void StartGame()
        {
            GameViewer.PrintGameIntro();
            GameViewer.PrintGameOptions();

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
            GameTasks.RandomFillByChosenGridSize();

            ///The Game is running until Ctrl + C is pressed 
            do
            { //StartTimer(); 
                while (!Console.KeyAvailable)
                {
                    GameTasks.CalculateNewCellStatus();
                    GameTasks.Print();

                }
                //StartTimer(); 
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            timer.Enabled = false;
            GameFileSaver.SaveGame(GameModel);
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
            GameTasks.CalculateNewCellStatus();
            GameTasks.Print();
        }
        public void ContinueGame()
        {
            var GameModel = GameFileSaver.LoadGame();
            if (GameModel == null)
            {
                NewGame();
            }
            do
            {
                while (!Console.KeyAvailable)
                {
                    //StartTimer();
                    GameTasks.Print();
                    GameTasks.CalculateNewCellStatus();
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            timer.Enabled = false;
            GameFileSaver.SaveGame(GameModel);
            Console.WriteLine("The game is over");
            Environment.Exit(0);
        }
    }
}


