using Reflex.Core;
using Reflex.Injectors;

namespace Source.Core.DI.Extensions
{
    public static class DiExtensions
    {
        public static T AttributeInject<T>(this T instance, Container container)
            where T : class // to avoid struct copying
        {
            AttributeInjector.Inject(instance, container);
            return instance;
        }
    }
}