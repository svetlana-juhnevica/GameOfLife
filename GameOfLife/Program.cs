using System;

namespace GameOfLife
{
    static class Program
    {
        public static void Main(string[] args)
        {
            GameTaskManager gameTaskManager = new GameTaskManager();
            gameTaskManager.Run();

            Console.ReadKey();
        }
    }
}



