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
            {
                int rows;
                Console.WriteLine("Rows : ");
                while (!int.TryParse(Console.ReadLine(), out rows))
                {

                    Console.WriteLine("This is not a valid input. Enter an integer > 0");

                }
                // if (rows < 0)

                int columns;
                Console.WriteLine("Columns : ");
                while (!int.TryParse(Console.ReadLine(), out columns))
                {
                    Console.WriteLine("This is not a valid input. Enter an integer > 0");
                }
               /* while (columns < 0)
                {
                    Console.WriteLine("This is not a valid input. Enter an integer > 0");
                }*/
                Console.WriteLine("To quit the game, press Esc : ");
                Console.WriteLine("To coninue the game, press any key : ");


                Game game = new Game(rows, columns);
                ConsoleKeyInfo input = new ConsoleKeyInfo();
                ///for each generation you need to press any key
                while (input.Key != ConsoleKey.Escape)
                {
                    input = Console.ReadKey(true);
                    game.Calculate();
                    Console.Clear();
                    game.Print();
                    // System.Threading.Thread.Sleep(1000);//Calculate the next generation after 1 second
                }
                Console.WriteLine("Game over!");


            }
        }
    }
}