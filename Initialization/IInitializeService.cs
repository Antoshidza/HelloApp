using Cysharp.Threading.Tasks;

namespace Source.Core.Initialization
{
    public interface IInitializeService
    {
        /// <summary>
        /// Will call IInitializable.Initialize() on initializable if it haven't get called from this service before
        /// </summary>
        public UniTask TryInitialize(IInitializable initializable);

        public void Reset();
    }
}