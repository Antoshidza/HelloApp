using Cysharp.Threading.Tasks;
using Reflex.Core;
using Reflex.Extensions;
using UnityEngine.SceneManagement;

namespace Source.Core.Presentation.SceneService
{
    public class SceneService : ISceneService
    {
        public async UniTask<Container> LoadSceneWithContainer(string sceneName)
        {
            await SceneManager.LoadSceneAsync(sceneName, new LoadSceneParameters(LoadSceneMode.Single)).ToUniTask();
            return SceneManager.GetSceneByName(sceneName).GetSceneContainer();
        }
    }
}