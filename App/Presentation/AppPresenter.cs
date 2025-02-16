using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using R3;
using Source.Core.Collections;
using Source.Core.Presentation.SceneService;
using Source.Core.StateMachine;

namespace Source.Core.App.Presentation
{
    /// <summary>
    /// Listen to app state and request load corresponding scene, after scene loaded search and use corresponding IAppStatePresenter
    /// </summary>
    public class AppPresenter : IDisposable
    {
        private readonly IDisposable _sub;
        private IDisposable _currentPresentation = Disposable.Empty;

        public AppPresenter(StateMachine<IAppState> appState, ISceneService sceneService, IEnumerable<IAppStatePresenter> statePresenters, TypedMap<string> sceneMap)
        {
            var statePresentersMap = new TypedMap<IAppStatePresenter>(statePresenters, presenter => presenter.AssociatedStateType);
            
            _sub = appState.State
                .Where(state => state != null)
                .Subscribe(state => OnAppStateChanged(state).Forget());
            
            return;

            async UniTaskVoid OnAppStateChanged(IAppState state)
            {
                _currentPresentation.Dispose();
                _currentPresentation = await statePresentersMap[state.GetType()].Present(state, await sceneService.LoadSceneWithContainer(sceneMap[state.GetType()]));
            }
        }

        public void Dispose() => _sub.Dispose();
    }
}