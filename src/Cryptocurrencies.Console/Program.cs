using Cryptocurrencies.Application;
using Cryptocurrencies.Application.Markets.GetMarketsPerCoinQuery;
using Cryptocurrencies.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((services) =>
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
    var mediator = services.GetRequiredService<IMediator>();
    
    var markets = await mediator.Send(new GetMarketsPerCoinQuery("bitcoin", 20));
    foreach (var history in markets)
    {
        Console.WriteLine(history);
    }
}

await host.StopAsync();