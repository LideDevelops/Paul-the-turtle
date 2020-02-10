using System.Collections.Generic;

namespace com.theTurtlePaul.PlayerArea.GameManager.Factory
{
    public interface FieldTileFactory
    {
        FieldTile CreateTile();

        IEnumerable<FieldTile> CreateTileList(int size);
    }
}