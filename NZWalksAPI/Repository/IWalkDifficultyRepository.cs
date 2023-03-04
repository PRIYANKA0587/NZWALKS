using NZWalksAPI.Models;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Repository
{
    public interface IWalkDifficultyRepository
    {
       Task<BaseResponse> GetAllWalkDifficultyAsync();
        Task<BaseResponse> GetWalkDifficultyById(Guid id);
       Task<BaseResponse> AddWalkDifficulty(WalkDifficultyAddRequest addRequest);
       Task<BaseResponse> DeleteWalkDifficulty(Guid id);
       Task<BaseResponse> UpdateWalkDifficulty(WalkDifficultyUpdateRequest updateRequest,Guid id);
    }
}
