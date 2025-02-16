using System;

namespace Source.Core.StateMachine
{
    public class StateMachineException : Exception
    {
        public StateMachineException(string msg) : base(msg)
        {
        }
    }
}