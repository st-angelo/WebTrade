using AutoMapper;
using WebTrade.Dtos;
using WebTrade.Entities;

namespace WebTrade;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Trade, TradeDto>()
            .ForMember(dest => dest.TradeId, src => src.MapFrom(x => x.Id))
            .ForMember(dest => dest.SecurityCode, src => src.MapFrom(x => x.Security.Code))
            .ForMember(dest => dest.TradeQuantity, src => src.MapFrom(x => x.Quantity))
            .ForMember(dest => dest.TradePrice, src => src.MapFrom(x => x.Price))
            .ForMember(dest => dest.TradeDate, src => src.MapFrom(x => x.Date))
            .ForMember(dest => dest.BuyerName, src => src.MapFrom(x => x.User.Name));
        CreateMap<Security, SecurityDto>();
        CreateMap<User, UserDto>();

        CreateMap<AddTradeDto, Trade>()
            .ForMember(dest => dest.Price, src => src.MapFrom((_, _, _, context) => context.Items["Price"]));
        CreateMap<UpdateSecurityDto, Security>()
            .ForMember(dest => dest.Id, src => src.MapFrom(x => x.SecurityId));
    }
}
