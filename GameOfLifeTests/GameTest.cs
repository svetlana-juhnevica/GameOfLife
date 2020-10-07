using GameOfLife;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GameOfLifeTests
{
    public class GameTests
    {
      //  public interface IGameViewer { int AskForGamesToDisplay(int val1, int val2, int val3, int val4, int val5, int val6, int val7, int val8); }

        /*
        [Fact]
        public void GamesForDisplaying_NewList_ReturnsListOFGameForDisplaying()
        {   //Arrange
           // gameTaskManager= new GameTaskManager();
            var mock = new Mock<IGameViewer>();
            List<int> mock= new List<>();
            mock.Setup(m => m.AskForGamesToDisplay(1, 2, 3, 4, 5, 6, 7, 8)).Returns(expected);
           
            //Act
            //var actual = gameTaskManager.GamesForDisplaying();
            for (int i = 0; i < 8; i++)
            {
                int AskForGamesToDisplay;
                mock.Add(AskForGamesToDisplay);
            }
            //Assert
            Assert.True(expected.SequenceEqual(actual));
        }*/
        [Fact]
        public void GamesGeneratorTest()
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
    }
}

            
                
           

