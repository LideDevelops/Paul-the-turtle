using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Timers;
using GameManager.Simulation.Scheduler;

namespace GameManager
{
    public class TimedCommanderScheduler : CommanderScheduler
    {
        private Queue<Commands> commandQueue;
        private Subject<Commands> commandObs;
        private int time;

        private Timer timer;
        public int Time { get => time; set => time = value; }

        public TimedCommanderScheduler(int time)
        {
            this.Time = time;
            commandQueue = new Queue<Commands>();
            commandObs = new Subject<Commands>();
            timer = new Timer(time);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        public void SetInterval(int time)
        {
            timer.Stop();
            timer.Interval = time;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Tick();
        }

        public void Queue(Commands command)
        {
            commandQueue.Enqueue(command);
        }

        public IDisposable Subscribe(Action<Commands> func)
        {
            return commandObs.Subscribe(func);
        }

        private void Tick()
        {
            commandObs.OnNext(commandQueue.Dequeue());
        }
    }
}