using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager.Player;
using GameManager.Simulation.Simulator;

namespace GameManager
{
    public class SingleTurtleSimulation : Simulator
    {
        private GameField _gameField;
        private TurtlePlayer _player;

        public SingleTurtleSimulation(GameField gameField, TurtlePlayer player)
        {
            _gameField = gameField;
            _player = player;
        }

        public void StartSimulation()
        {
            _player.StartTurtleMain(_gameField);
        }
    }
}