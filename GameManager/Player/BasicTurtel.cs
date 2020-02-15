using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager.Simulation.Scheduler;

namespace GameManager
{
    public abstract class BasicTurtel : Player
    {
        public void StartTurtleMain(GameField gameField, CommanderScheduler scheduler)
        {
            TurtleMain();
        }

        public abstract void TurtleMain();
    }
}