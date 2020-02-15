using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Timers;
using GameManager.Simulation.Scheduler;

namespace GameManager
{
    public class TimedCommanderScheduler : AbstractScheduler
    {
        private int time;
        private Timer timer;
        public int Time { get => time; set => time = value; }

        public TimedCommanderScheduler(int time) : base()
        {
            this.Time = time;
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
    }
}