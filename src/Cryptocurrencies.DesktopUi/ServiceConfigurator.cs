using Cryptocurrencies.DesktopUi.DIItems;
using Cryptocurrencies.DesktopUi.ViewModels;
using Cryptocurrencies.DesktopUi.Views;
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
        
        services.AddSingleton<IFrameContainer, FrameContainer>();

        services.AddSingleton<MainWindow>();
        services.AddTransient<MainWindowViewModel>();
        
        services.AddSingleton<CoinsPage>();
        services.AddTransient<CoinsViewModel>();
        
        services.AddSingleton<CurrencyPage>();
        services.AddTransient<CurrencyViewModel>();
        
        services.AddSingleton<ConvertPage>();
        services.AddTransient<ConvertViewModel>();
        
        return services;
    }
}