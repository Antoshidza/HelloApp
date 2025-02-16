using Cysharp.Threading.Tasks;
using Reflex.Core;

namespace Source.Core.DI
{
    public interface IInstaller
    {
        public void InstallBindings(ContainerBuilder builder);
        public UniTask InstallContainer(Container container);
    }
}