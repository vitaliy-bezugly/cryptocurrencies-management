using Cryptocurrencies.Application;
using Cryptocurrencies.Application.Rates.GetRateByIdQuery;
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
    
    var rate = await mediator.Send(new GetRateByIdQuery("ukrainian-hryvnia"));
    Console.WriteLine(rate);
}

await host.StopAsync();