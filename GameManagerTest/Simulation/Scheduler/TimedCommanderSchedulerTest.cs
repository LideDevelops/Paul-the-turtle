using GameManager;
using GameManager.Simulation.Scheduler;
using Xunit;

namespace GameManagerTest.Simulation.Scheduler
{
    public class TimedCommanderSchedulerTest
    {
        private CommanderScheduler testee;

        public TimedCommanderSchedulerTest()
        {
            testee = new TimedCommanderScheduler(10);
        }

        [Fact]
        public void QueueCommandTest()
        {
            testee.Queue(Commands.MoveForward);
            Commands cmd = Commands.TurnRight;
            var disposable = testee.Subscribe(command =>
            {
                cmd = command;
            });
            System.Threading.Thread.Sleep(100); // Force current thread to sleep so RX thread can take over
            // This might not be the smartest solution for testing multithreaded code.
            // Feel free to change it to a more elegant solution
            Assert.Equal(Commands.MoveForward, cmd);
            disposable.Dispose();
        }

        [Fact]
        public void QueueCommandWithExtraTest()
        {
            testee.Queue(Commands.Speak, "Hey");
            Commands cmd = Commands.TurnRight;
            string extraVal = "";
            var disposable = testee.Subscribe((command, val) =>
            {
                cmd = command;
                extraVal = val;
            });
            System.Threading.Thread.Sleep(100); // Force current thread to sleep so RX thread can take over
            // This might not be the smartest solution for testing multithreaded code.
            // Feel free to change it to a more elegant solution
            Assert.Equal(Commands.Speak, cmd);
            Assert.Equal("Hey", extraVal);
            disposable.Dispose();
        }
    }
}