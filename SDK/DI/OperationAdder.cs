using Microsoft.Extensions.DependencyInjection;

namespace StratusSDK
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