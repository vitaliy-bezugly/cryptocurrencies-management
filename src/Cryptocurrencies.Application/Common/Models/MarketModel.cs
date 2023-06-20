using AutoMapper;
using Cryptocurrencies.Application.Common.Mappings;
using Cryptocurrencies.Contracts.Dtos;

namespace Cryptocurrencies.Application.Common.Models;

public record MarketModel : IMapFrom<MarketDto>
{
    public string ExchangeId { get; init; } = string.Empty;
    
    public string BaseId { get; init; } = string.Empty;
    
    public string QuoteId { get; init; } = string.Empty;
    
    public string BaseSymbol { get; init; } = string.Empty;
    
    public string QuoteSymbol { get; init; } = string.Empty;
    
    public double VolumeUsd24Hr { get; init; }

    public double PriceUsd { get; init; }
    
    public double VolumePercent { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<MarketDto, MarketModel>()
            .ForMember(dest => dest.PriceUsd,
                opt => opt.MapFrom(src => Math.Round(double.Parse(src.PriceUsd), 4)));
    }
}