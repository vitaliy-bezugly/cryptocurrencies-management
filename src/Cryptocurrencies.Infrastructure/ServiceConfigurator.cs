using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Infrastructure.Apis;
using Cryptocurrencies.Infrastructure.Routes;
using Microsoft.Extensions.DependencyInjection;

namespace Cryptocurrencies.Infrastructure;

public static class ServiceConfigurator
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ICoinApi, CoinCapApi>();
        
        services.AddHttpClient<ICoinApi, CoinCapApi>(client =>
        {
            client.BaseAddress = new Uri(ApiRoutes.CoinCap.Base);
        });
        
        services.Decorate<ICoinApi, CoinApiValidationDecorator>();

        return services;
    }
}