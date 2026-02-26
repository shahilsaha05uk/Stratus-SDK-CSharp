using Microsoft.Extensions.DependencyInjection;

namespace StratusSDK
{
    internal sealed class ManualResolver(StratusOptions options) : OperationResolver()
    {
        private readonly IServiceProvider provider = 
            new ServiceCollection()
                .AddStratusExtensions(options)
                .BuildServiceProvider();
        public override T Resolve<T>() => provider.GetRequiredService<T>();
    }
}