using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager.Simulation.Scheduler;

namespace GameManager.Player
{
    public interface TurtlePlayer : PlaceableObject
    {
        void StartTurtleMain(GameField gameField, CommanderScheduler scheduler);

        void TurtleMain();

        void MoveForward();
    }
}