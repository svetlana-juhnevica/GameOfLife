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
        private Game game;
        private List<Game> games;
        public GameFileSaver()
        {
          //Game  game = new Game();
          List<Game> games = new List<Game>();
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
            try { 
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
        public void SaveGames(List<Game> games)
        {
            foreach(Game game in games)
            {
                SaveGame(game);
            }
        }
        public List<Game> LoadGames()
        {
            foreach(Game game in games)
            {
                LoadGame();
                games.Add(game);
            }
            return games;
        }
         }
}


