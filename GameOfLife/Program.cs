using System;

namespace GameOfLife
{
    static class Program
    {
       public static void Main(string[] args)
        {
            {
                ///Introduction to the Game
                Console.WriteLine("Welcome to the Game of Life! ");
                Console.WriteLine("To quit the game, press Ctr + C : ");
                Console.WriteLine(" "); //Makes empty space between the Intro and choice of the field 

                ///User chooses the size of the grid
                 int rows;
                 Console.WriteLine("Enter the number of Rows from 1 to 20 : ");
                 while (!int.TryParse(Console.ReadLine(), out rows) || rows < 0 || rows > 20)
                 {
                     Console.WriteLine("This is not a valid input. Enter an integer from 1 to 20");
                 }
                 int columns;
                 Console.WriteLine("Enter the number of Columns from 1 to 20: ");
                 while (!int.TryParse(Console.ReadLine(), out columns) || columns < 0 || columns > 20)
                 {
                     Console.WriteLine("This is not a valid input. Enter an integer from 1 to 20");
                 }

                Game game = new Game(rows, columns);
                game.RandomFill();
                ///The Game is running until Ctrl + C is pressed
                bool RunGame = true;
                while (RunGame)
                {
                    game.Print();
                   // game.AliveCellsCount();
                    game.CalculateNewCellStatus();
                }
                Console.CancelKeyPress += (sender, args) =>
                {
                    RunGame = false;
                };
                }  
        }
    }
}
//timer