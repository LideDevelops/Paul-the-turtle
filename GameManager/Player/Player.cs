using com.theTurtlePaul.PlayerArea.GameManager;

namespace GameManager.Player
{
    public interface TurtlePlayer : PlaceableObject
    {
        void StartTurtleMain(GameField gameField);

        void TurtleMain();

        void MoveForward();

        void TurnRight();
    }
}