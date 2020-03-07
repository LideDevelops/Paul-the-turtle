using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager.Player;
using GameManager.Simulation.Scheduler;

namespace GameManager
{
    public abstract class BasicTurtel : TurtlePlayer
    {
        public string Name { get; set; }

        public virtual bool CanWalkThrough()
        {
            return true;
        }

        public void MoveForward()
        {
            throw new System.NotImplementedException();
        }

        public void StartTurtleMain(GameField gameField, CommanderScheduler scheduler)
        {
            TurtleMain();
        }

        public abstract void TurtleMain();
    }
}