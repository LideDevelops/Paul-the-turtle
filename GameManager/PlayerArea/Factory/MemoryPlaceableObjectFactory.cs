namespace com.theTurtlePaul.PlayerArea.GameManager.Factory
{
    public class MemoryPlaceableObjectFactory<T> : PlaceableObjectFactory<T> where T : PlaceableObject, new()
    {
        public T CreatePlaceableObject()
        {
            return new T();
        }

        public T CreatePlaceableObject(string name)
        {
            var obj = CreatePlaceableObject();
            obj.Name = name;
            return obj;
        }
    }
}