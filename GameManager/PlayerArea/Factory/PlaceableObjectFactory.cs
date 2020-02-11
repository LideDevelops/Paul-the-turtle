namespace com.theTurtlePaul.PlayerArea.GameManager.Factory
{
    public interface PlaceableObjectFactory<T> where T : PlaceableObject
    {
        T CreatePlaceableObject();

        T CreatePlaceableObject(string name);
    }
}