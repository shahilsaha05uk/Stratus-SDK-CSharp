using Microsoft.Extensions.DependencyInjection;
using StratusSDK.Core.Operation;
using StratusSDK;

namespace StratusSDK.DI
{
    public static class OperationAdder
    {
        public static IServiceCollection AddOperation<T>(this IServiceCollection services) where T : BaseOperation
        {
            services.AddScoped<T>(); // register concrete type

            services.AddScoped<BaseOperation>(sp =>
                sp.GetRequiredService<T>()); // register as base

            return services;
        }
    }
}