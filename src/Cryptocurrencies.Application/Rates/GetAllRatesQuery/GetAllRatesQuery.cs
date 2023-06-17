using System.Text;
using Cryptocurrencies.Contracts.Models;
using MediatR;

namespace Cryptocurrencies.Application.Rates.GetAllRatesQuery;

public record GetAllRatesQuery : IRequest<IReadOnlyCollection<RateModel>>
{ }