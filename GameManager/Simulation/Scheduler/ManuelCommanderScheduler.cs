using System;
using System.Collections.Generic;
using System.Reactive.Subjects;

namespace GameManager.Simulation.Scheduler
{
    /// <summary>
    /// Scheduler where you have to call the tick function by yourself.
    /// </summary>
    public class ManuelCommanderScheduler : AbstractScheduler
    {
        public ManuelCommanderScheduler(IObservable<int> tickObservable) : base()
        {
            tickObservable.Subscribe(amountOfTicks => processTicks(amountOfTicks));
        }

        private void processTicks(int tickAmount)
        {
            for (int i = 0; i < tickAmount; i++)
            {
                Tick();
            }
        }
    }
}