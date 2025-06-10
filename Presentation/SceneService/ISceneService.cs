using Cysharp.Threading.Tasks;
using R3;
using Reflex.Core;
using UnityEngine;

namespace Source.Core.Presentation.SceneService
{
    /// <summary>
    /// Use this service when you need to load scene so other modules can react to obtained scene-container.
    /// The common use case is when your scene contains multiple separate views and you use multiple presenters for separated game parts.
    /// So you can start load scene from main presenter and others will just react on SceneLoaded and resolve it's dependencies.
    /// </summary>
    public interface ISceneService
    {
        public Observable<AsyncOperation> LoadingOperationStarted { get; }

        public UniTask<Container> LoadSceneWithContainer(string sceneName);
    }
}