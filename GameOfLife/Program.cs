using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace GameOfLife
{
    static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Rows : ");
            int rows = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Columns : ");
            int columns = Int32.Parse(Console.ReadLine());
           // Console.WriteLine("To quit the game, press Esc : ");

            Game game = new Game(rows, columns);
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            while (input.Key != ConsoleKey.Escape)
            {
                input = Console.ReadKey(true);
                game.Calculate();
                game.Print();
               // System.Threading.Thread.Sleep(1000);//Calculate the next generation after 1 second
               
            }
             Console.WriteLine("Game over!");
             
        }
        }
    }
      

        


        
    

