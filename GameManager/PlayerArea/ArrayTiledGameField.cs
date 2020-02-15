using System;
using System.Collections.Generic;
using System.Linq;
using com.theTurtlePaul.PlayerArea.GameManager.Factory;

namespace com.theTurtlePaul.PlayerArea.GameManager
{
    public class ArrayTiledGameField : GameField
    {
        private FieldTileFactory fieldTileFactoryMock;
        private FieldTile[][] tiles;

        public ArrayTiledGameField(int qubeSize) : this(qubeSize, new BasicFieldTileFactory())
        {
        }

        public ArrayTiledGameField(int qubeSize, FieldTileFactory fieldTileFactoryMock)
        {
            this.fieldTileFactoryMock = fieldTileFactoryMock;
            tiles = CreateTilesetForMap(qubeSize);
        }

        public bool PlaceObjectOnTile(uint x, uint y, PlaceableObject placeableObjectMock)
        {
            var tile = GetFieldTile(x, y);
            if (tile == null)
            {
                return false;
            }
            return tile.PlaceObject(placeableObjectMock);
        }

        public FieldTile GetFieldTile(uint x, uint y)
        {
            return DoesTileExist(x, y) ? tiles[y][x] : null;
        }

        private bool DoesTileExist(uint x, uint y)
        {
            return (x < tiles.Length) || (y < tiles.Length);
        }

        private FieldTile[][] CreateTilesetForMap(int qubeSize)
        {
            FieldTile[][] tiles = new FieldTile[qubeSize][];
            for (int i = 0; i < qubeSize; i++)
            {
                tiles[i] = fieldTileFactoryMock.CreateTileList(qubeSize).ToArray();
            }
            return tiles;
        }
    }
}