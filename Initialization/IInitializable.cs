using Cysharp.Threading.Tasks;

namespace Source.Core.Initialization
{
    public interface IInitializable
    {
        public UniTask Initialize();
    }
}