using System;
using System.Collections.Generic;
using System.Reactive.Subjects;

namespace GameManager.Simulation.Scheduler
{
    public abstract class AbstractScheduler : CommanderScheduler
    {
        private Queue<SimpleCommand> commandQueue;
        private Subject<SimpleCommand> commandObs;

        public AbstractScheduler()
        {
            commandQueue = new Queue<SimpleCommand>();
            commandObs = new Subject<SimpleCommand>();
        }

        public void Queue(Commands command)
        {
            Queue(command, null);
        }

        public IDisposable Subscribe(Action<Commands> func)
        {
            return commandObs.Subscribe(x => func(x.Command));
        }

        protected void Tick()
        {
            commandObs.OnNext(commandQueue.Dequeue());
        }

        public void Queue(Commands speak, string value)
        {
            commandQueue.Enqueue(new SimpleCommand(speak, value));
        }

        public IDisposable Subscribe(Action<Commands, string> func)
        {
            return commandObs.Subscribe(x => func(x.Command, x.Extra));
        }
    }
}