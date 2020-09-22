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
             File.WriteAllText(@"C:\Users\svetlana.juhnevica\source\repos\GameOfLife\GameOfLife.json", jsonString);
         }
        /// <summary>
        /// Load the game from the file
        /// </summary>
        public GameModel LoadGame()
         {
             if (File.Exists(@"C:\Users\svetlana.juhnevica\source\repos\GameOfLife\GameOfLife.json"))
             {
                 var jsonString = File.ReadAllText(@"C:\Users\svetlana.juhnevica\source\repos\GameOfLife\GameOfLife.json");
                 var gameModel = JsonConvert.DeserializeObject<GameModel>(jsonString);
                 return gameModel;
             }
             else
             {
                 throw new FileNotFoundException("File not found", (@"C:\Users\svetlana.juhnevica\source\repos\GoL\GameOfLife.json"));
             }
         }
        
    }
}

/*  public void SaveGame()
       {
           string filename = @"C:\Users\svetlana.juhnevica\source\repos\GameOfLife\GameOfLife.bin";
           if (filename == null) throw new ArgumentNullException(nameof(filename));
           using (var file = File.Create(filename))
           {
               var serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
               serializer.Serialize(file.GameModel);
           }
       }
       public void LoadGame(GameModel gameModel)
       {
           string filename = @"C:\Users\svetlana.juhnevica\source\repos\GameOfLife\GameOfLife.bin";
           if (filename == null) throw new ArgumentNullException(nameof(filename));
           if (!File.Exists(filename)) throw new FileNotFoundException("File not found", filename);
           using (var file = File.OpenRead(filename))
           {
               var serializer = new BinaryFormatter();
               serializer.Deserialize(file);

           }
       }*/
