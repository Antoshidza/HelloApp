using System;
using Cysharp.Threading.Tasks;
using Reflex.Core;

namespace Source.Core.App.Presentation
{
    public abstract class AAppStatePresenter<TAppState> : IAppStatePresenter
        where TAppState : IAppState
    {
        public Type AssociatedStateType => typeof(TAppState);

        public UniTask<IDisposable> Present(IAppState appState, Container viewContainer) 
            => Present((TAppState)appState, viewContainer);

        protected abstract UniTask<IDisposable> Present(TAppState appSate, Container viewContainer);
    }
}