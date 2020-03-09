using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager.Player;
using GameManager.PlayerArea;
using GameManager.TurtleExceptions;

namespace GameManager
{
    public abstract class BasicTurtel : TurtlePlayer
    {
        protected GameField _gameField = null;
        private readonly float TurnDegree = 90;

        public string Name { get; set; }

        public Transform Transform { get; }

        public BasicTurtel(GameField gameField) : this()
        {
            _gameField = gameField;
        }

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
            var movedForward = TryMoveForward();
            if (movedForward == false)
            {
                throw new CantWalkThereException(Transform.Position.Y, Transform.Position.X);
            }
        }

        private bool TryMoveForward()
        {
            var oldPosition = Transform.Position;
            Transform.PlaceAt(Transform.GetNormalizedForwardPosition());
            if (Transform.Position.Y < 0
                || Transform.Position.X < 0)
            {
                Transform.PlaceAt(oldPosition);
                return false;
            }
            return TryPlaceOnGameField(oldPosition);
        }

        public bool TryPlaceOnGameField(Position fallbackPositonOnFailure)
        {
            var couldPlaceOnGameField = _gameField.PlaceObjectOnTile((uint)Transform.Position.X, (uint)Transform.Position.Y, this);
            if (couldPlaceOnGameField == false)
            {
                Transform.PlaceAt(fallbackPositonOnFailure);
            }
            return couldPlaceOnGameField;
        }

        public void TurnRight()
        {
            Transform.RotateAroundY(TurnDegree);
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