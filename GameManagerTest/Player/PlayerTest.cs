using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager;
using GameManager.Player;
using GameManager.PlayerArea;
using GameManager.TurtleExceptions;
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
            testee = Substitute.ForPartsOf<BasicTurtel>(gameFieldMock);
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
            gameFieldMock.PlaceObjectOnTile(Arg.Any<uint>(), Arg.Any<uint>(), testee).Returns(true);
            testee.MoveForward();
            Assert.Equal(new Position(0, 1, 0), testee.Transform.Position);
            gameFieldMock.PlaceObjectOnTile(Arg.Any<uint>(), Arg.Any<uint>(), testee).Returns(true);
            testee.TurnRight();
            testee.MoveForward();
            Assert.Equal(new Position(1, 1, 0), testee.Transform.Position);
            gameFieldMock.PlaceObjectOnTile(Arg.Any<uint>(), Arg.Any<uint>(), testee).Returns(false);
            testee.TurnRight();
            testee.TurnRight();
            Assert.Throws<CantWalkThereException>(() => testee.MoveForward());
            testee.TurnRight();
            testee.TurnRight();
            Assert.Throws<CantWalkThereException>(() => testee.MoveForward());
        }

        [Fact]
        public void TurnAroundTest()
        {
            testee.TurnRight();
            Assert.Equal(90, testee.Transform.Rotation.DegreeRotatedOnY);
            testee.TurnRight();
            Assert.Equal(180, testee.Transform.Rotation.DegreeRotatedOnY);
            testee.TurnRight();
            Assert.Equal(270, testee.Transform.Rotation.DegreeRotatedOnY);
            testee.TurnRight();
            Assert.Equal(0, testee.Transform.Rotation.DegreeRotatedOnY);
        }
    }
}