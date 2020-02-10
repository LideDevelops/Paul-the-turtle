using System.Collections.Generic;

namespace com.theTurtlePaul.PlayerArea.GameManager.Factory
{
    public class BasicFieldTileFactory : FieldTileFactory
    {
        public FieldTile CreateTile()
        {
            return new BasicFieldTile();
        }

        public IEnumerable<FieldTile> CreateTileList(int size)
        {
            var elements = CreateTileArray(size);
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = CreateTile();
            }
            return elements;
        }

        protected FieldTile[] CreateTileArray(int size)
        {
            if (size <= 0)
            {
                return new FieldTile[0];
            }
            return new FieldTile[size];
        }
    }
}