using AutoMapper;
using Cryptocurrencies.Application.Common.Mappings;
using Cryptocurrencies.Contracts.Dtos;

namespace Cryptocurrencies.Application.Common.Models;

public record CoinModel : IMapFrom<CoinDto>
{
    public string Id { get; init; } = string.Empty;
    
    public int Rank { get; init; }
    
    public string Symbol { get; init; } = string.Empty;
    
    public string Name { get; init; } = string.Empty;
    
    public double Supply { get; init; }
    
    public double MaxSupply { get; init; }
    
    public double MarketCapUsd { get; init; }
    
    public double VolumeUsd24Hr { get; init; }
    
    public double PriceUsd { get; init; }
    
    public double ChangePercent24Hr { get; init; }
    
    public double Vwap24Hr { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CoinDto, CoinModel>()
            .ForMember(dest => dest.PriceUsd, 
                opt => opt.MapFrom(src => Math.Round(double.Parse(src.PriceUsd), 4)))
            .ForMember(dest => dest.Supply, 
                opt => opt.MapFrom(src => Math.Round(double.Parse(src.Supply), 4)))
            .ForMember(dest => dest.MarketCapUsd, 
                opt => opt.MapFrom(src => Math.Round(double.Parse(src.MarketCapUsd), 4)))
            .ForMember(dest => dest.VolumeUsd24Hr, 
                opt => opt.MapFrom(src => Math.Round(double.Parse(src.VolumeUsd24Hr), 4)))
            .ForMember(dest => dest.ChangePercent24Hr, 
                opt => opt.MapFrom(src => Math.Round(double.Parse(src.ChangePercent24Hr), 5)));
    }
}