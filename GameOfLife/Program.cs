using System;

namespace GameOfLife
{
    static class Program
    {
        public static void Main(string[] args)
        {
            GameTaskManager gameTaskManager = new GameTaskManager(new GameViewer());
            gameTaskManager.Run();

            Console.ReadKey();
        }
    }
}



