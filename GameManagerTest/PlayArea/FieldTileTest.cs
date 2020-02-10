using com.theTurtlePaul.PlayerArea.GameManager;
using NSubstitute;
using Xunit;

namespace GameManagerTest
{
    public class FieldTileTest
    {
        private FieldTile testee;
        private PlaceableObject objectToPlaceOnTile;

        public FieldTileTest()
        {
            objectToPlaceOnTile = Substitute.For<PlaceableObject>();
            testee = new BasicFieldTile();
        }

        [Fact]
        public void PlaceObjectOnTileTest()
        {
            Assert.True(testee.PlaceObject(objectToPlaceOnTile));
            Assert.False(testee.PlaceObject(objectToPlaceOnTile));
        }

        [Fact]
        public void RemovePlaceableObjectTest()
        {
            testee.PlaceObject(objectToPlaceOnTile);
            Assert.True(testee.RemoveObject());
            Assert.False(testee.RemoveObject());
        }

        [Fact]
        public void GetPlacedObjectTest()
        {
            Assert.Null(testee.PlacedObject);
            Assert.True(testee.PlaceObject(objectToPlaceOnTile));
            Assert.NotNull(testee.PlacedObject);
        }

        [Fact]
        public void CanPlayerMoveOnTileTest()
        {
            Assert.True(testee.CanPlayerMoveOnTile());
            objectToPlaceOnTile.CanWalkThrough().Returns(false);
            testee.PlaceObject(objectToPlaceOnTile);
            Assert.False(testee.CanPlayerMoveOnTile());
            testee.RemoveObject();
            Assert.True(testee.CanPlayerMoveOnTile());
        }

        [Fact]
        public void IsTileEmptyTest()
        {
            Assert.True(testee.IsTileEmpty());
            testee.PlaceObject(objectToPlaceOnTile);
            Assert.False(testee.IsTileEmpty());
        }
    }
}