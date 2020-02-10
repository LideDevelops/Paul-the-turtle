using com.theTurtlePaul.PlayerArea.GameManager;
using com.theTurtlePaul.PlayerArea.GameManager.Factory;
using NSubstitute;
using Xunit;

namespace GameManagerTest
{
    public class GameFieldTest
    {
        private int fieldSize = 10;
        private FieldTile tileMock;
        private FieldTileFactory fieldTileFactoryMock;
        private PlaceableObject placeableObjectMock;
        private GameField testee;

        public GameFieldTest()
        {
            placeableObjectMock = Substitute.For<PlaceableObject>();
            fieldTileFactoryMock = Substitute.For<FieldTileFactory>();
            tileMock = Substitute.For<FieldTile>();
            FieldTile[] tiles = new FieldTile[fieldSize];
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i] = tileMock;
            }
            fieldTileFactoryMock.CreateTileList(fieldSize).Returns(tiles);

            testee = new GameField(fieldSize, fieldTileFactoryMock);
        }

        [Fact]
        public void CreateField()
        {
            Assert.Equal(tileMock, testee.GetFieldTile(0, 0));
        }

        [Fact]
        public void GetInvalidTileTest()
        {
            Assert.Null(testee.GetFieldTile(11, 11));
            Assert.Null(testee.GetFieldTile(10, 10));
        }

        [Fact]
        public void PlaceObjectOnTileTest()
        {
            tileMock.PlaceObject(placeableObjectMock).Returns(true);
            Assert.True(testee.PlaceObjectOnTile(0, 0, placeableObjectMock));
        }

        [Fact]
        public void PlaceObjectOnTileThatDoesNotExist()
        {
            Assert.False(testee.PlaceObjectOnTile(10, 10, placeableObjectMock));
            Assert.False(testee.PlaceObjectOnTile(11, 11, placeableObjectMock));
        }
    }
}