using System.Text;
using Cryptocurrencies.Application.Common.Models;
using MediatR;

namespace Cryptocurrencies.Application.Rates.GetAllRatesQuery;

public record GetAllRatesQuery : IRequest<IReadOnlyCollection<RateModel>>
{ }