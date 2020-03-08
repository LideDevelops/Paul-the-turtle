using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager;
using GameManager.Player;
using NSubstitute;
using Xunit;

namespace GameManagerTest
{
    public class PlayerTest
    {
        private TurtlePlayer testee;
        private GameField gameFieldMock;

        public PlayerTest()
        {
            gameFieldMock = Substitute.For<GameField>();
            testee = Substitute.ForPartsOf<BasicTurtel>();
        }

        [Fact]
        public void StartTurtleMainTest()
        {
            testee.StartTurtleMain(gameFieldMock);
            testee.Received(1).TurtleMain();
        }

        [Fact]
        public void MoveForwardTest()
        {
            testee.MoveForward();
            Assert.False(true);
        }
    }
}