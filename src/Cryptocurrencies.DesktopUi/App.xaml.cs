using System.Windows;
using Cryptocurrencies.Application;
using Cryptocurrencies.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cryptocurrencies.DesktopUi;

public partial class App : System.Windows.Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddDesktopUiServices()
                    .AddApplicationServices()
                    .AddInfrastructureServices();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();
        
        ShowStartupWindow();
        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();
        base.OnExit(e);
    }
    
    private void ShowStartupWindow()
    {
        var startupWindow = _host.Services.GetRequiredService<MainWindow>();
        startupWindow.Show();
    }
}