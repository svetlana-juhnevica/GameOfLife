using GameOfLife;
using Moq;
using Xunit;

namespace GameOfLifeTests
{
    public class GameTests
    {
        [Fact]
        public void GamesGenerator_IfGamesGenerated_GamesCountTrue()
        {
            //Arrange
            var mock = new Mock<IGameViewer>();
            mock.Setup(m => m.AskForGamesCount()).Returns(2);
            mock.Setup(m => m.AskForColumns()).Returns(5);
            mock.Setup(m => m.AskForRows()).Returns(6);
            GameTaskManager gameTaskManager = new GameTaskManager(mock.Object);

            //Act
            gameTaskManager.GenerateGames();

            //Assert
            Assert.Equal(2, gameTaskManager.Games.Count);
            Assert.Equal(5, gameTaskManager.Games[0].Columns);
            Assert.Equal(6, gameTaskManager.Games[0].Rows);
        }


        [Fact]
        public void GamesForDisplaying_IfGamesAreAdded_ListOfGamesFilled()
        {
            //Arrange
            var mock = new Mock<IGameViewer>();
            mock.Setup(m => m.AskForDisplayedGamesCount()).Returns(2);
            mock.Setup(m => m.AskForGamesToDisplay()).Returns(12);
            GameTaskManager gameTaskManager = new GameTaskManager(mock.Object);

            //Act
            gameTaskManager.GamesForDisplaying();

            //Assert
            Assert.Equal(2, gameTaskManager.SelectedGamesNumber.Count);
            Assert.Equal(12, gameTaskManager.SelectedGamesNumber[0]);
            Assert.Equal(12, gameTaskManager.SelectedGamesNumber[1]);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(5, 5)]
        [InlineData(20, 20)]
        public void GameRowsColumnsGenerationCount_RandomFill_True(int rows, int columns)
        {
           //Arrange
            var game = new Game(rows, columns);
           
            //Act
            game.Randomize();
           
            //Assert
            Assert.Equal(rows, game.Rows);
            Assert.Equal(columns, game.Columns);
            Assert.Equal(1, game.GenerationCount);
        }

         [Theory] 
         [InlineData(2, 2)] 
         [InlineData(5, 5)] 
         [InlineData(20, 20)] 
        public void CalculateNewCellStatus_GenerationCountAliveCellsCount_True(int rows, int columns)
        { 
            //Arrange
            var game = new Game(rows, columns);
           
            //Act
            game.CalculateNewCellStatus();

            //Assert
            Assert.Equal(rows, game.Rows);
            Assert.Equal(columns, game.Columns);
            Assert.Equal(2, game.GenerationCount);
        }
    }
}


            
                
           

