using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cryptocurrencies.DesktopUi;

public static class ServiceConfigurator
{
    public static IServiceCollection AddDesktopUiServices(this IServiceCollection services)
    {
        services.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddDebug();
        });

        services.AddSingleton<MainWindow>();
        
        return services;
    }
}