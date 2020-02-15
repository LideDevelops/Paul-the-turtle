using System;

namespace GameManager.Simulation.Scheduler
{
    public interface CommanderScheduler
    {
        void Queue(Commands command);

        void Queue(Commands speak, string value);

        IDisposable Subscribe(Action<Commands> func);

        IDisposable Subscribe(Action<Commands, string> func);
    }
}