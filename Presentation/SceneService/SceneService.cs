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
            if(SceneManager.GetActiveScene().name != sceneName)
                await SceneManager.LoadSceneAsync(sceneName, new LoadSceneParameters(LoadSceneMode.Single)).ToUniTask();
            else
                await UniTask.NextFrame(); // wait 1 frame before SceneScope write itself to Reflex scene dictionary
            return SceneManager.GetSceneByName(sceneName).GetSceneContainer();
        }
    }
}