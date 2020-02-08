namespace com.theTurtlePaul.PlayerArea.GameManager
{
    public interface FieldTile
    {
        PlaceableObject PlacedObject { get; }

        bool PlaceObject(PlaceableObject objectToPlaceOnTile);
        bool RemoveObject();
        bool CanPlayerMoveOnTile();
    }
}