using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager.Simulation.Scheduler;

namespace GameManager
{
    public interface Player
    {
        void TurtleMain();

        void StartTurtleMain(GameField gameField, CommanderScheduler scheduler);
    }
}