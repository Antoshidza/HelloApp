using Cysharp.Threading.Tasks;
using R3;
using Reflex.Core;
using Reflex.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Core.Presentation.SceneService
{
    public class SceneService : ISceneService
    {
        private readonly Subject<AsyncOperation> _loadingOperationStarted = new();

        public Observable<AsyncOperation> LoadingOperationStarted => _loadingOperationStarted;

        public async UniTask<Container> LoadSceneWithContainer(string sceneName)
        {
            if(SceneManager.GetActiveScene().name != sceneName)
            {
                var loadingOperation = SceneManager.LoadSceneAsync(sceneName, new LoadSceneParameters(LoadSceneMode.Single));
                _loadingOperationStarted.OnNext(loadingOperation);
                await loadingOperation.ToUniTask();
            }
            else
                await UniTask.NextFrame(); // wait 1 frame before SceneScope write itself to Reflex scene dictionary
            return SceneManager.GetSceneByName(sceneName).GetSceneContainer();
        }
    }
}