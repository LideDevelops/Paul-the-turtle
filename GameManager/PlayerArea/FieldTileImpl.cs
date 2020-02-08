using System;
using System.Collections.Generic;
using System.Text;

namespace com.theTurtlePaul.PlayerArea.GameManager
{
    public class FieldTileImpl : FieldTile
    {
        public PlaceableObject PlacedObject { get; private set; }

        public FieldTileImpl()
        {
            PlacedObject = null;
        }

        public bool PlaceObject(PlaceableObject objectToPlaceOnTile)
        {
            if (PlacedObject == null)
            {
                PlacedObject = objectToPlaceOnTile;
                return true;
            }
            return false;
        }

        public bool RemoveObject()
        {
            if (PlacedObject == null)
            {
                return false;
            }
            PlacedObject = null;
            return true;
        }

        public bool CanPlayerMoveOnTile()
        {
            return (PlacedObject == null) ? true : PlacedObject.CanWalkThrough();
        }
    }
}