using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Source.Core.Initialization
{
    public class InitializeService : IInitializeService
    {
        private readonly HashSet<IInitializable> _initialized = new();

        async UniTask IInitializeService.TryInitialize(IInitializable initializable)
        {
            if(_initialized.Add(initializable))
                await initializable.Initialize();
        }

        public void Reset() => _initialized.Clear();
    }
}