using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public interface IGameViewer
    {
        event Action GamePaused;

        int AskForColumns();
        int AskForDisplayedGamesCount();
        int AskForGamesCount();
        int AskForGamesToDisplay();
        int AskForRows();
        PausedGameMenu PauseGameOptions();
        void Print(Game game);
        void PrintGameIntro();
        GameMenu PrintGameOptions();
        void PrintGames(List<Game> games, List<int> selectedGamesNumber, int aliveGamesCount, int totalAliveCellsCount);
        void WarningOfNoSavedGame();
        void WarningOfWrongCommand();
        void WarningOfWrongInput();
    }
}