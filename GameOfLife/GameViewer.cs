using System;
using System.Text;

namespace GameOfLife
{
    public class GameViewer
    {
        /// <summary>
        /// Introduction to the Game 
        /// </summary>
        public void PrintGameIntro()
        {
            Console.WriteLine("Welcome to the Game of Life! ");
            Console.WriteLine(" "); //Makes empty space between Intro and selection 
        }
        /// <summary>
        /// Options to choose whether to start a new game, continue the game or quit
        /// </summary>
        public void PrintGameOptions()
        {
            Console.WriteLine("To continue the game, press C : ");
            Console.WriteLine("To quit the game, press Q : ");
            Console.WriteLine("To start a new game, press N : ");
        }
    }
}