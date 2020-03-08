using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager.Player;
using GameManager.PlayerArea;

namespace GameManager
{
    public abstract class BasicTurtel : TurtlePlayer
    {
        protected GameField _gameField = null;

        public string Name { get; set; }

        public Transform Transform { get; }

        public BasicTurtel()
        {
            Transform = new Transform2DGrid();
        }

        public virtual bool CanWalkThrough()
        {
            return true;
        }

        public void MoveForward()
        {
            _gameField.PlaceObjectOnTile(0, 0, this);
        }

        public void PlaceAt(int x, int y, int z)
        {
            Transform.PlaceAt(x, y, z);
        }

        public void StartTurtleMain(GameField gameField)
        {
            _gameField = gameField;
            TurtleMain();
        }

        public abstract void TurtleMain();
    }
}