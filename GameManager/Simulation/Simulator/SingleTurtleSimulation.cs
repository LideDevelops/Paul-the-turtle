using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager.Player;
using GameManager.Simulation.Scheduler;
using GameManager.Simulation.Simulator;

namespace GameManager
{
    public class SingleTurtleSimulation : Simulator
    {
        private GameField _gameField;
        private TurtlePlayer _player;
        private CommanderScheduler _scheduler;

        public SingleTurtleSimulation(GameField gameField, TurtlePlayer player, CommanderScheduler scheduler)
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