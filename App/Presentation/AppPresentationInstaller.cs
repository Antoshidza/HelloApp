using Reflex.Core;
using Source.Core.Presentation.SceneService;

namespace Source.Core.App.Presentation
{
    public static class AppPresentationInstaller
    {
        public static void InstallAppPresentation(this ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(typeof(AppPresenter));
            containerBuilder.AddSingleton(typeof(SceneService), typeof(ISceneService));

            // force app-presenter to be created
            containerBuilder.OnContainerBuilt += container => container.Single<AppPresenter>();
        }
    }
}