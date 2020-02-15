using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager.Simulation.Scheduler;
using GameManager.Simulation.Simulator;

namespace GameManager
{
    public class SingleTurtleSimulation : Simulator
    {
        private GameField _gameField;
        private Player _player;
        private CommanderScheduler _scheduler;

        public SingleTurtleSimulation(GameField gameField, Player player, CommanderScheduler scheduler)
        {
            _gameField = gameField;
            _player = player;
            _scheduler = scheduler;
        }

        public void StartSimulation()
        {
            _player.StartTurtleMain(_gameField, _scheduler);
        }
    }
}