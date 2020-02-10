namespace com.theTurtlePaul.PlayerArea.GameManager
{
    public class BasicFieldTile : FieldTile
    {
        public PlaceableObject PlacedObject { get; private set; }

        public BasicFieldTile()
        {
            PlacedObject = null;
        }

        public bool PlaceObject(PlaceableObject objectToPlaceOnTile)
        {
            if (IsTileEmpty())
            {
                PlacedObject = objectToPlaceOnTile;
                return true;
            }
            return false;
        }

        public bool RemoveObject()
        {
            if (IsTileEmpty())
            {
                return false;
            }
            PlacedObject = null;
            return true;
        }

        public bool CanPlayerMoveOnTile()
        {
            return IsTileEmpty() ? true : PlacedObject.CanWalkThrough();
        }

        public bool IsTileEmpty()
        {
            return PlacedObject == null;
        }
    }
}