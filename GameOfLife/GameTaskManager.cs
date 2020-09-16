using System;
using System.Timers;

namespace GameOfLife
{
    public class GameTaskManager
    {
        private GameLifeCycle GameLifeCycle;
        public static Timer timer;
        public GameTaskManager()
        {
            GameLifeCycle = new GameLifeCycle();
        }
        /// <summary>
        /// Undergoes the full cycle of the game
        /// </summary>
        public void NewGame()
        {
            GameLifeCycle.RandomFillByChosenGridSize();
            ///The Game is running until Ctrl + C is pressed
            do
            { //StartTimer();
                while (!Console.KeyAvailable)
                {
                    
                    GameLifeCycle.Print();
                   
                    GameLifeCycle.CalculateNewCellStatus();
                 }
                  //StartTimer();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            timer.Enabled = false;
            //SaveGame();
            Console.WriteLine("The game is over");
            Environment.Exit(0);
        }
        /*  public void StartTimer()
          {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
          }
     public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
          GameLifeCycle.CalculateNewCellStatus();
          GameLifeCycle.Print();
        }*/
}
}

