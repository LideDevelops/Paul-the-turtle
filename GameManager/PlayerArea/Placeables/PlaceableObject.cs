using GameManager.PlayerArea;

namespace com.theTurtlePaul.PlayerArea.GameManager
{
    public interface PlaceableObject
    {
        string Name { get; set; }
        Transform Transform { get; }

        bool CanWalkThrough();

        void PlaceAt(int x, int y, int z);
    }
}