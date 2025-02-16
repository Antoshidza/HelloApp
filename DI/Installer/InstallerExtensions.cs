using Cysharp.Threading.Tasks;
using Reflex.Core;

namespace Source.Core.DI
{
    public static class InstallerExtensions
    {
        public static async UniTask<Container> Install(this IInstaller installer, Container parentContainer)
        {
            var container = parentContainer.Scope(installer.InstallBindings);
            await installer.InstallContainer(container);
            return container;
        }
    }
}