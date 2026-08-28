using Microsoft.Extensions.DependencyInjection;
using StratusSDK;
using StratusSDK.Resolvers;

namespace StratusSDK.Resolvers
{
    public sealed class DIResolver(IServiceProvider provider) : OperationResolver
    {
        public override T Resolve<T>() => provider.GetRequiredService<T>();
    }
}
