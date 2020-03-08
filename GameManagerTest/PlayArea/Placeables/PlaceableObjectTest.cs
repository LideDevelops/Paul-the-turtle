using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager;
using Xunit;

namespace GameManagerTest.PlayArea
{
    public class PlaceableObjectTest
    {
        private PlaceableObject testee;

        public PlaceableObjectTest()
        {
            testee = new BasicWall();
        }

        [Fact]
        public void IsPassableTest()
        {
            Assert.False(testee.CanWalkThrough());
        }

        [Fact]
        public void SetAndGetName()
        {
            testee.Name = "Wall";
            Assert.Equal("Wall", testee.Name);
        }

        [Fact]
        public void MovePlaceableObjectToPositionTest()
        {
            testee.PlaceAt(0, 0, 0);
            Assert.Equal(0, testee.Transform.Position.X);
            Assert.Equal(0, testee.Transform.Position.Y);
            Assert.Equal(0, testee.Transform.Position.Z);
        }
    }
}