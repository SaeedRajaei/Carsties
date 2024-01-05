using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;

namespace AuctionService.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Auction, AuctionDto>()
            .IncludeMembers(x => x.Item);

        CreateMap<Item, AuctionDto>().IncludeMembers(i => i.Auction);
        CreateMap<CreateAuctionDto, Auction>()
        .ForMember(f => f.Item, o => o.MapFrom(s => s));

        CreateMap<CreateAuctionDto, Item>();


    }

}
