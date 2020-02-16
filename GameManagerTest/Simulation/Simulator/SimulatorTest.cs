using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager;
using GameManager.Player;
using GameManager.Simulation.Scheduler;
using GameManager.Simulation.Simulator;
using NSubstitute;
using Xunit;

namespace GameManagerTest.Simulation.SimulatorTest
{
    public class SimulatorTest
    {
        private Simulator testee;
        private CommanderScheduler schedulerMock;
        private TurtlePlayer playerMock;
        private GameField gameFieldMock;

        public SimulatorTest()
        {
            schedulerMock = Substitute.For<CommanderScheduler>();
            playerMock = Substitute.For<TurtlePlayer>();
            gameFieldMock = Substitute.For<GameField>();

            testee = new SingleTurtleSimulation(gameFieldMock, playerMock, schedulerMock);
        }

        [Fact]
        public void StartSimulationTest()
        {
            testee.StartSimulation();
            playerMock.Received(1).StartTurtleMain(gameFieldMock, schedulerMock);
        }
    }
}