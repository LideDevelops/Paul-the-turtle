using System;
using System.Collections.Generic;
using System.Text;

namespace GameManager.Simulation.Scheduler
{
    public enum Commands
    {
        MoveForward = 0,
        TurnRight,
        CheckForward,
        Speak
    }

    internal interface Command
    {
        Commands Command { get; }
        string Extra { get; }
    }

    internal class SimpleCommand : Command
    {
        public SimpleCommand(Commands command, string extra)
        {
            Command = command;
            Extra = extra;
        }

        public Commands Command { get; private set; }
        public string Extra { get; private set; }
    }
}