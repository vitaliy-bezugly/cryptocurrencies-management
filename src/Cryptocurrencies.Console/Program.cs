using Cryptocurrencies.Application;
using Cryptocurrencies.Application.Coins.GetAllCoinsQuery;
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
    
    var coins = await mediator.Send(new GetAllCoinsQuery(20));
    foreach (var coin in coins)
    {
        Console.WriteLine(coin);
    }
}

await host.StopAsync();