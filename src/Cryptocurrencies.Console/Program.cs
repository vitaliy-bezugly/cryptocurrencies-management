using Cryptocurrencies.Application;
using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddLogging();
        
        services.AddApplicationServices();
        services.AddInfrastructureServices();
    })
    .Build();

await host.StartAsync();

using(host.Services.CreateScope())
{
    var services = host.Services;
    var api = services.GetRequiredService<ICoinApi>();
    var response = await api.GetRateByIdAsync("ethereum");

    Console.WriteLine(response.Data);
    Console.WriteLine($"Timestamp: {response.Timestamp}");
}

await host.StopAsync();