using System;
using Cysharp.Threading.Tasks;
using Reflex.Core;

namespace Source.Core.App.Presentation
{
    public interface IAppStatePresenter
    {
        public Type AssociatedStateType { get; }
        
        public UniTask<IDisposable> Present(IAppState appState, Container viewContainer);
    }
}