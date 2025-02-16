using Cysharp.Threading.Tasks;

namespace Source.Core.StateMachine
{
    public interface IState
    {
        public UniTask OnEnter() => UniTask.CompletedTask;

        public UniTask OnExit() => UniTask.CompletedTask;
    }
}