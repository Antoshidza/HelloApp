using Reflex.Core;

namespace Source.Core.Presentation
{
    public class ViewContainerLink
    {
        public Container Container { get; private set; }

        public ViewContainerLink(Container container)
            => Container = container;
    }
}