using System.Net;
using Cryptocurrencies.Application.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cryptocurrencies.Application.Common.Behaviours;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException("Can not find requested resource");
            }
            
            _logger.LogError(ex, $"Request: HttpRequestException for Request {request}");
            throw;
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogError(ex, $"Request: Unhandled Exception for Request {requestName} {request}");
            throw;
        }
    }
}