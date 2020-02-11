using com.theTurtlePaul.PlayerArea.GameManager;

namespace GameManager
{
    public class BasicWall : PlaceableObject
    {
        public string Name { get; set; }

        public bool CanWalkThrough()
        {
            return false; // You cann ever walk through a wall silly
        }
    }
}