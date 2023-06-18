using System.Windows.Controls;
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
        
        services.AddSingleton<FrameContainer>();

        services.AddTransient<MainWindow>();
        services.AddTransient<MainWindowViewModel>();
        
        services.AddTransient<CoinsPage>();
        services.AddTransient<CoinsViewModel>();
        
        services.AddTransient<CurrencyPage>();
        services.AddTransient<CurrencyViewModel>();
        
        services.AddTransient<ConvertPage>();
        services.AddTransient<ConvertViewModel>();
        
        return services;
    }
}