namespace com.theTurtlePaul.PlayerArea.GameManager
{
    public interface GameField
    {
        FieldTile GetFieldTile(uint x, uint y);

        bool PlaceObjectOnTile(uint x, uint y, PlaceableObject placeableObjectMock);
    }
}