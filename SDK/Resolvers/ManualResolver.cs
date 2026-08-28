using Microsoft.Extensions.DependencyInjection;
using StratusSDK.Config;
using StratusSDK.DI;
using StratusSDK;
using StratusSDK.Resolvers;

namespace StratusSDK.Resolvers
{
    internal sealed class ManualResolver(StratusOptions options) : OperationResolver()
    {
        readonly IServiceProvider provider =
            new ServiceCollection()
                .AddStratusExtensions(options)
                .BuildServiceProvider();
        public override T Resolve<T>() => provider.GetRequiredService<T>();
    }
}