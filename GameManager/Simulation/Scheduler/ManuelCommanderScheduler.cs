using System;
using System.Collections.Generic;
using System.Reactive.Subjects;

namespace GameManager.Simulation.Scheduler
{
    /// <summary>
    /// Scheduler where you have to call the tick function by yourself.
    /// </summary>
    public class ManuelCommanderScheduler : CommanderScheduler
    {
        private Queue<Commands> commandQueue;
        private Subject<Commands> commandObs;

        public ManuelCommanderScheduler(IObservable<int> tickObservable)
        {
            commandQueue = new Queue<Commands>();
            commandObs = new Subject<Commands>();
            tickObservable.Subscribe(amountOfTicks => processTicks(amountOfTicks));
        }

        public void Queue(Commands command)
        {
            commandQueue.Enqueue(command);
        }

        public IDisposable Subscribe(Action<Commands> func)
        {
            return commandObs.Subscribe(func);
        }

        private void processTicks(int tickAmount)
        {
            for (int i = 0; i < tickAmount; i++)
            {
                Tick();
            }
        }

        private void Tick()
        {
            commandObs.OnNext(commandQueue.Dequeue());
        }
    }
}