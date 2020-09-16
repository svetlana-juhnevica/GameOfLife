using System;

namespace GameOfLife
{
    static class Program
    {
        public static void Main(string[] args)
        {  
                 GameTaskManager gameTM = new GameTaskManager();
                 
                ///Introduction to the Game
                 Console.WriteLine("Welcome to the Game of Life! ");
                 Console.WriteLine(" "); //Makes empty space between Intro and selection
                
                /// User makes choice: to continue, quit or start a new game
                 while (true)
                { 
                Console.WriteLine("To continue the game, press C : ");
                Console.WriteLine("To quit the game, press Q : ");
                Console.WriteLine("To start a new game, press N : ");
                
                    string input = Console.ReadLine().ToLower();
                    switch (input)   
                    {
                        //if "quit" is pressed
                        case "q":
                        Environment.Exit(0);
                        break;
                       
                        //if "start a new game" is pressed
                        case "n":
                        gameTM.NewGame();
                        break;
                        
                        //if "continue the game" is pressed
                       /* case "c":
                        gameTaskManager.ContinueGame();
                        break;*/
                        
                        // if unknown command is pressed
                        default:
                        Console.WriteLine("Unrecognized command, make another choice");
                        break;
                    }
                }
            }
        }
    }

                       

