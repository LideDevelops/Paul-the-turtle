using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager;
using GameManager.Simulation.Scheduler;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameManagerTest
{
    public class PlayerTest
    {
        private Player testee;
        private GameField gameFieldMock;
        private CommanderScheduler commanderSchedulerMock;

        public PlayerTest()
        {
            gameFieldMock = Substitute.For<GameField>();
            commanderSchedulerMock = Substitute.For<CommanderScheduler>();
            testee = Substitute.ForPartsOf<BasicTurtel>();
        }

        [Fact]
        public void StartTurtleMainTest()
        {
            testee.StartTurtleMain(gameFieldMock, commanderSchedulerMock);
            testee.Received(1).TurtleMain();
        }

        [Fact]
        public void MoveForwardTest()
        {
        }
    }
}