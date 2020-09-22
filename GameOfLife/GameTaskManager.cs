using System;
using System.Timers;

namespace GameOfLife
{
    public class GameTaskManager
    {
        private CellStatusCalculator cellStatusCalculator;
        private GameViewer gameViewer;
        private GameFileSaver gameFileSaver;
        private Timer timer;
        public GameTaskManager()
        {
            cellStatusCalculator= new CellStatusCalculator();
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
            gameViewer.GetGridSize();
            cellStatusCalculator.RandomFillByChosenGridSize();

            ///The Game is running until Ctrl + C is pressed 
            do
            {
                while (!Console.KeyAvailable)
                {
                   StartTimer();
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
            GameModel gameModel = new GameModel();
            cellStatusCalculator.CalculateNewCellStatus();
            gameViewer.Print(gameModel);
            gameFileSaver.SaveGame(gameModel);
        }
        public void ContinueGame()
        {
            var GameModel = gameFileSaver.LoadGame();
            if (GameModel == null)
            {
               Console.WriteLine("You don't have any saved games, start a new one");
               NewGame();
            }
            do
            {
                while (!Console.KeyAvailable)
                {
                    StartTimer();
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            timer.Enabled = false;
            Console.WriteLine("The game is over");
            Environment.Exit(0);
        }
    }
}



