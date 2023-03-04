using NZWalksAPI.Models;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Repository
{
    public interface IWalkRepository
    {
       Task<BaseResponse> GetAllWalksAsync();
        Task<BaseResponse> GetWalkByIdAsync(Guid id);
        Task<BaseResponse> AddWalkAsync(WalkAddRequest walkAddRequest);
        Task<BaseResponse> UpdateWalkAsync(WalkUpdateRequest walkUpdateRequest, Guid id);
        Task<BaseResponse> DeleteWalkAsync(Guid id);
    }
}
