using GameOfLife.GameOfLife;
using Newtonsoft.Json;
using System.IO;

namespace GameOfLife
{
    public class GameFileSaver
    {
        private Game game;
        public GameFileSaver()
        {
            Game game = new Game();
        }
        /// <summary>
        /// Save the game to the file
        /// </summary>
        /// <param name="GameModel"></param>
      public void SaveGame(Game game)
         {
             var jsonString = JsonConvert.SerializeObject(game);
             File.WriteAllText("GameOfLife.json", jsonString);
         }
        /// <summary>
        /// Load the game from the file
        /// </summary>
        public Game LoadGame()
         {
             if (File.Exists("GameOfLife.json"))
             {
                 var jsonString = File.ReadAllText("GameOfLife.json");
                 var game = JsonConvert.DeserializeObject<Game>(jsonString);
                 return game;
             }
             return null;   
            }
         }
        
    }


