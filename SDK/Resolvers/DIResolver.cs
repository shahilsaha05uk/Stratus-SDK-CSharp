using Microsoft.Extensions.DependencyInjection;

namespace StratusSDK
{
    public sealed class DIResolver(IServiceProvider provider) : OperationResolver
    {
        public override T Resolve<T>() => provider.GetRequiredService<T>();
    }
}
