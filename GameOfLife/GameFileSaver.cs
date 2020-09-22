using Newtonsoft.Json;
using System.IO;

namespace GameOfLife
{
    public class GameFileSaver
    {
        /// <summary>
        /// Save the game to the file
        /// </summary>
        /// <param name="GameModel"></param>
      public void SaveGame(GameModel gameModel)
         {
             var jsonString = JsonConvert.SerializeObject(gameModel);
             File.WriteAllText("GameOfLife.json", jsonString);
         }
        /// <summary>
        /// Load the game from the file
        /// </summary>
        public GameModel LoadGame()
         {
             if (File.Exists("GameOfLife.json"))
             {
                 var jsonString = File.ReadAllText("GameOfLife.json");
                 var gameModel = JsonConvert.DeserializeObject<GameModel>(jsonString);
                 return gameModel;
             }
             return null;   
            }
         }
        
    }


