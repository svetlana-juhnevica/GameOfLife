using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife
{
    /// <summary> 
    /// A class to save the game to the file and load it from the file
    /// </summary> 
    public class GameFileSaver
    {
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
            try
            {
                var jsonString = File.ReadAllText("GameOfLife.json");
                var game = JsonConvert.DeserializeObject<Game>(jsonString);
                return game;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        /// <summary>
        /// Saves all games to the file
        /// </summary>
        /// <param name="games">List of games</param>
        public void SaveGames(List<Game> games)
        {
            try
            {
                var jsonString = JsonConvert.SerializeObject(games);
                File.WriteAllText("GameOfLife.json", jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Loads all games from the file
        /// </summary>
        /// <param name="games">List of games</param>
        public List<Game> LoadGames()
         {
              try
              {
                  var jsonString = File.ReadAllText("GameOfLife.json");
                  var games = JsonConvert.DeserializeObject<List<Game>>(jsonString);
                  return games;
              }
              catch (Exception e)
              {
                  Console.WriteLine(e.Message);
                  return null;
              }
         }
    }
}


