using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager.PlayerArea;

namespace GameManager
{
    public class BasicWall : PlaceableObject
    {
        public string Name { get; set; }

        public Transform Transform { get; private set; }

        public BasicWall()
        {
            Transform = new Transform2DGrid();
        }

        public bool CanWalkThrough()
        {
            return false; // You cann ever walk through a wall silly
        }

        public void PlaceAt(int x, int y, int z)
        {
            Transform.PlaceAt(x, y, z);
        }
    }
}