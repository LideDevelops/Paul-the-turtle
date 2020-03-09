using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager.Player;
using GameManager.PlayerArea;
using GameManager.TurtleExceptions;

namespace GameManager
{
    public abstract class BasicTurtel : TurtlePlayer
    {
        protected GameField _gameField = null;

        public string Name { get; set; }

        public Transform Transform { get; }

        public BasicTurtel(GameField gameField)
        {
            Transform = new Transform2DGrid();
            _gameField = gameField;
        }

        public virtual bool CanWalkThrough()
        {
            return true;
        }

        public void MoveForward()
        {
            var oldPosition = Transform.Position;
            Transform.PlaceAt(Transform.GetNormalizedForwardPosition());
            if (Transform.Position.Y < 0 || Transform.Position.X < 0)
            {
                Transform.PlaceAt(oldPosition);
                throw new CantWalkThereException(Transform.Position.Y, Transform.Position.X);
            }
            if (_gameField.PlaceObjectOnTile((uint)Transform.Position.X, (uint)Transform.Position.Y, this) == false)
            {
                Transform.PlaceAt(oldPosition);
                throw new CantWalkThereException(Transform.Position.Y, Transform.Position.X);
            }
        }

        public void TurnRight()
        {
            Transform.RotateAroundY(90);
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