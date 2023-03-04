using AutoMapper;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Profiles
{
    public class WalkProfiles : Profile
    {
        public WalkProfiles()
        {
            CreateMap<Walk, WalkResponse>().ReverseMap();
            CreateMap<Walk, WalkAddRequest>().ReverseMap();
            CreateMap<WalkDifficulty, WalkDifficultyResponse>().ReverseMap();
            CreateMap<Walk, WalkUpdateRequest>().ReverseMap();
        }
    }
}
