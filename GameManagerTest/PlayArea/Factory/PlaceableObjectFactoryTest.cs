using com.theTurtlePaul.PlayerArea.GameManager.Factory;
using GameManager;
using Xunit;

namespace GameManagerTest.PlayArea.Factory
{
    public class PlaceableObjectFactoryTest
    {
        private PlaceableObjectFactory<BasicWall> testee;

        public PlaceableObjectFactoryTest()
        {
            testee = new MemoryPlaceableObjectFactory<BasicWall>();
        }

        [Fact]
        public void CreatePlaceableObjectTest()
        {
            var obj = testee.CreatePlaceableObject();
            Assert.NotNull(obj);
        }

        [Fact]
        public void CreatePlaceableObjectWithNameTest()
        {
            var obj = testee.CreatePlaceableObject("Test");
            Assert.NotNull(obj);
            Assert.Equal("Test", obj.Name);
        }
    }
}