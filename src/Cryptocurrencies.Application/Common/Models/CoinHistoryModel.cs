using AutoMapper;
using Cryptocurrencies.Application.Common.Mappings;
using Cryptocurrencies.Contracts.Dtos;

namespace Cryptocurrencies.Application.Common.Models;

public record CoinHistoryModel : IMapFrom<CoinHistoryDto>
{
    public double PriceUsd { get; init; }

    public DateTime Time { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CoinHistoryDto, CoinHistoryModel>()
            .ForMember(dest => dest.Time, 
                opt => 
                    opt.MapFrom(src => UnixTimeStampToDateTime(src.Time)));
    }
    
    public static DateTime UnixTimeStampToDateTime(long unixTimeStamp )
    {
        // Unix timestamp is seconds past epoch
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTime = dateTime.AddMilliseconds( unixTimeStamp );
        return dateTime;
    }
}