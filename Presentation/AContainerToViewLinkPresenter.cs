using System;
using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using Reflex.Core;
using Source.Core.Initialization;

namespace Source.Core.Presentation
{
    /// <summary>
    /// Base class which present model from it's container (or parent containers)
    /// by binding it to view container obtained by ViewContainerLink 
    /// </summary>
    public abstract class AContainerToViewLinkPresenter : IInitializable, IDisposable
    {
        [Inject] private readonly ViewContainerLink _viewContainerLink;
        private IDisposable _presentation;

        protected abstract UniTask<IDisposable> Present(Container viewContainer);
        
        public async UniTask Initialize() => _presentation = await Present(_viewContainerLink.Container);

        public void Dispose() => _presentation.Dispose();
    }
}