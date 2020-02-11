namespace com.theTurtlePaul.PlayerArea.GameManager
{
    public interface PlaceableObject
    {
        string Name { get; set; }

        bool CanWalkThrough();
    }
}