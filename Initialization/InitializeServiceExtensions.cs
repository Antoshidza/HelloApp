using System.Collections.Generic;
using Reflex.Core;

namespace Source.Core.Initialization.Extensions
{
    public static class InitializeServiceExtensions
    {
        public static async Cysharp.Threading.Tasks.UniTask TryInitialize(this IInitializeService initializeService, IEnumerable<IInitializable> initializables)
        {
            foreach (var initializable in initializables)
                await initializeService.TryInitialize(initializable);
        }

        public static async Cysharp.Threading.Tasks.UniTask InitializeAllInContainer(this IInitializeService initializeService, Container container) 
            => await initializeService.TryInitialize(container.All<IInitializable>());
    }
}