using System;
using Cysharp.Threading.Tasks;
using Reflex.Core;
using UnityEngine;

namespace Source.Core.DI
{
    public abstract class AHierarchicalInstaller : MonoBehaviour, Reflex.Core.IInstaller
    {
        private readonly InstallHelper _installHelper = new();
        
        public void InstallBindings(ContainerBuilder containerBuilder) => 
            Install(containerBuilder);

        protected abstract void Install(ContainerBuilder containerBuilder);

        protected abstract UniTaskVoid OnScopeInstalled(Container container);

        protected void Install(string scopeName, ContainerBuilder containerBuilder, Action<ContainerBuilder> installCallback,
            Action<Container> onContainerBuiltCallback = null)
        {
            _installHelper.BeginBuild(scopeName);
            installCallback(containerBuilder);
            containerBuilder.OnContainerBuilt += container => 
            {
                onContainerBuiltCallback?.Invoke(container);
                _installHelper.EndBuild(scopeName);
                OnScopeInstalled(container);
            };
        }
    }
}