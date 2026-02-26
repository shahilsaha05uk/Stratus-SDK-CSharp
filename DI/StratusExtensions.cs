using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StratusSDK.Core.Interfaces;

namespace StratusSDK
{
    public static class StratusExtensions
    {
        public static IServiceCollection AddStratusExtensions(
            this IServiceCollection services,
            Action<StratusOptions> configure)
        {
            // Register the options
            services.Configure(configure);
            services.AddSingleton(sp =>
                sp.GetRequiredService<IOptions<StratusOptions>>().Value);

            RegisterCore(services);
            return services;
        }

        public static IServiceCollection AddStratusExtensions(
            this IServiceCollection services,
            StratusOptions options)
        {
            // Register the options
            services.AddSingleton(options);
            RegisterCore(services);
            return services;
        }

        private static void RegisterCore(IServiceCollection services)
        {
            // Delegating Handler
            services.AddTransient<StratusDelegatingHandler>();

            // HttpClient
            services.AddHttpClient<StratusClient>((sp, client) =>
            {
                var options = sp.GetRequiredService<StratusOptions>();
                client.BaseAddress = new Uri(options.BaseUrl);
            })
            .AddHttpMessageHandler<StratusDelegatingHandler>();

            // SDK
            services.AddScoped<IStratusSDK, StratusSDK>();

            // Token services
            services.AddSingleton<ITokenEndpointClient, ZohoTokenEndpointClient>();
            services.AddSingleton<ITokenManager, TokenManager>();

            // Operations
            services.AddAllOperations();
        }
    }
}