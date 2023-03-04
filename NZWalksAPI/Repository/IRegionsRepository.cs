using NZWalksAPI.Models;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Repository
{
    public interface IRegionsRepository
    {
        Task<BaseResponse> GetAllRegionsAsync();
        Task<BaseResponse> GetRegionByIdAsync(Guid id);
        Task<BaseResponse> AddRegionAsync(RegionAddRequest regionAddRequest);

        Task<BaseResponse> DeleteRegionAsync(Guid id);

        Task<BaseResponse> UpdateRegionAsync(RegionUpdateRequest regionUpdateRequest, Guid id);

    }
}
