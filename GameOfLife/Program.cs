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
                Console.WriteLine("Welcome to the Game of Life! ");
                Console.WriteLine("To quit the game, press Ctr + C : ");
                Console.WriteLine(" "); //Makes empty space between the Intro and choice of the field 
               
                int rows;
                Console.WriteLine("Enter the number of Rows : ");
                while (!int.TryParse(Console.ReadLine(), out rows) || rows < 0)
                {

                    Console.WriteLine("This is not a valid input. Enter an integer > 0");

                }

                int columns;
                Console.WriteLine("Enter the number of Columns : ");
                while (!int.TryParse(Console.ReadLine(), out columns) || columns < 0)
                {
                    Console.WriteLine("This is not a valid input. Enter an integer > 0");
                }

                Game game = new Game(rows, columns);

                /*
                ///In this method for each generation you need to press any key 

                 ConsoleKeyInfo input = new ConsoleKeyInfo();
                 while (input.Key != ConsoleKey.Escape)
                 {
                     input = Console.ReadKey(true);  
                     game.Calculate();
                     Console.Clear();
                     game.Print();
                     game.AliveCellsCount();
                     // System.Threading.Thread.Sleep(1000);//Calculate the next generation after 1 second
                 }
                 Console.WriteLine("Game over!");
                */

                bool RunGame = true;
                while (RunGame)
                {
                    game.Calculate();
                    game.Print();
                    game.AliveCellsCount();
                    System.Threading.Thread.Sleep(1000);//Game is updated each second 
                }
                Console.CancelKeyPress += (sender, args) =>
                {
                    RunGame = false;
                };
            }
               
            }
        }
    }
