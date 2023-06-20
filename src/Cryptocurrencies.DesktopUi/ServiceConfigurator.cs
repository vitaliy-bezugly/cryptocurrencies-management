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
        services.AddSingleton<ICoinContainer, CoinContainer>();

        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowViewModel>();
        
        services.AddSingleton<CoinsPage>();
        services.AddSingleton<CoinsViewModel>();
        
        services.AddSingleton<CoinPage>();
        services.AddSingleton<CoinViewModel>();
        
        services.AddSingleton<ConvertPage>();
        services.AddSingleton<ConvertViewModel>();
        
        return services;
    }
}