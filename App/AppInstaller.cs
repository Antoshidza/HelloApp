using Reflex.Core;
using Source.Core.Initialization;
using AppStateMachine = Source.Core.StateMachine.StateMachine<Source.Core.App.IAppState>;

namespace Source.Core.App
{
    public static class AppInstaller
    {
        public static void InstallApp<TInitialState>(this ContainerBuilder containerBuilder, bool autorun = true)
            where TInitialState : IAppState
        {
            containerBuilder.AddSingleton(typeof(AppStateMachine), typeof(AppStateMachine));
            containerBuilder.AddSingleton(typeof(InitializeService), typeof(IInitializeService));
            
            if(autorun)
                containerBuilder.OnContainerBuilt += container => container.Single<AppStateMachine>().Start<TInitialState>();
        }
    }
}