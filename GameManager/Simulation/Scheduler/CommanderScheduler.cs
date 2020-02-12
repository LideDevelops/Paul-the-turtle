using System;

namespace GameManager.Simulation.Scheduler
{
    public interface CommanderScheduler
    {
        void Queue(Commands moveForward);

        IDisposable Subscribe(Action<Commands> func);
    }
}