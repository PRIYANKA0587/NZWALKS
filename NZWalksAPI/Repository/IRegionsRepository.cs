using NZWalksAPI.Models;

namespace NZWalksAPI.Repository
{
    public interface IRegionsRepository
    {
        Task<BaseResponse> GetAllRegionsAsync();

    }
}
