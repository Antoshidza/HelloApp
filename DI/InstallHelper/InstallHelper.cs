using System;
using System.Collections.Generic;

namespace Source.Core.DI
{
    public class InstallHelper
    {
        private readonly HashSet<string> _registeredContainers = new();
        
        public void BeginBuild(string name)
        {
            if (!_registeredContainers.Add(name))
                throw new ArgumentException($"{name} is already registered");
        }

        public void EndBuild(string name)
        {
            if(!_registeredContainers.Remove(name))
                throw new ArgumentException($"{name} wasn't register OR have been already unregistered");
        }
    }
}