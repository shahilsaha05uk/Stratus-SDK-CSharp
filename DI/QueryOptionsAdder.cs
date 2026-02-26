using Microsoft.Extensions.DependencyInjection;

namespace StratusSDK
{
    public static class QueryOptionsAdder
    {
        public static IServiceCollection AddQueryOptions<T>(this IServiceCollection services) where T : class
        {
            services.AddScoped<T>(); // register concrete type
            return services;
        }
    }
}