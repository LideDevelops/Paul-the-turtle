using GameManager.Simulation.Scheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using Xunit;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace GameManagerTest.Simulation.Scheduler
{
    public class ManuelCommanderSchedulerTest
    {
        private CommanderScheduler testee;
        private Subject<int> tickSubject;

        public ManuelCommanderSchedulerTest()
        {
            tickSubject = new Subject<int>();
            testee = new ManuelCommanderScheduler(tickSubject);
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
            tickSubject.OnNext(1);
            System.Threading.Thread.Sleep(10); // Force current thread to sleep so RX thread can take over
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
            tickSubject.OnNext(1);
            System.Threading.Thread.Sleep(100); // Force current thread to sleep so RX thread can take over
            // This might not be the smartest solution for testing multithreaded code.
            // Feel free to change it to a more elegant solution
            Assert.Equal(Commands.Speak, cmd);
            Assert.Equal("Hey", extraVal);
            disposable.Dispose();
        }
    }
}