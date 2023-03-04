using AutoMapper;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Region, RegionResponse>();
            CreateMap<RegionResponse, Region>();

            CreateMap<Region, RegionAddRequest>().ReverseMap();
        }
    }
}
