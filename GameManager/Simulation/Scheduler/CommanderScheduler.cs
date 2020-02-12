using System;

namespace GameManager.Simulation.Scheduler
{
    public interface CommanderScheduler
    {
        void Queue(Commands command);

        IDisposable Subscribe(Action<Commands> func);
    }
}