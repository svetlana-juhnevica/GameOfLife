using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;

namespace GameOfLife
{
    public class GameFileSaver
    {
        /// <summary>
        /// Save the game to the file
        /// </summary>
        /// <param name="GameModel"></param>
        public void SaveGame(GameModel GameModel)
         {
             var jsonString = JsonSerializer.Serialize(GameModel);
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
                 var GameModel = JsonSerializer.Deserialize<GameModel>(jsonString);
                 return GameModel;
             }
             else
             {
                 throw new FileNotFoundException("File not found", (@"C:\Users\svetlana.juhnevica\source\repos\GoL\GameOfLife.json"));
             }
         }
      /*  public void SaveGame()
        {
            var GameModel = new GameModel();
            string filename = @"C:\Users\svetlana.juhnevica\source\repos\GameOfLife\GameOfLife.bin";
            if (filename == null) throw new ArgumentNullException(nameof(filename));
            using (var file = File.Create(filename))
            {
                var serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                serializer.Serialize(file.GameModel);
            }
        }
        public void LoadGame(file.GameModel)
        {
            string filename = @"C:\Users\svetlana.juhnevica\source\repos\GameOfLife\GameOfLife.bin";
            if (filename == null) throw new ArgumentNullException(nameof(filename));
            if (!File.Exists(filename)) throw new FileNotFoundException("File not found", filename);
            using (var file = File.OpenRead(filename))
            {
                var serializer = new BinaryFormatter();
                serializer.Deserialize(file);

            }*/
        }
    }


