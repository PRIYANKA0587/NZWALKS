using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Repository
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public WalkDifficultyRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<BaseResponse> AddWalkDifficulty(WalkDifficultyAddRequest walkDifficultyAdd)
        {
            if(walkDifficultyAdd == null)
            {
                return new BaseResponse() { Message="Not found", StatusCode = System.Net.HttpStatusCode.NotFound};
            }
            var domainWalk = _mapper.Map<Walk>(walkDifficultyAdd);
            domainWalk.Id = Guid.NewGuid();
            var responseDomain= _db.Walks.AddAsync(domainWalk);
            await _db.SaveChangesAsync();
            var walkdifficultyResponse = _mapper.Map<WalkResponse>(responseDomain);
            return new BaseResponse() { Message = "Created", Data = walkdifficultyResponse, StatusCode = System.Net.HttpStatusCode.Created }; ;
        }

        public async Task<BaseResponse> DeleteWalkDifficulty(Guid id)
        {
           var domainResponse= await _db.WalkDifficulty.FirstOrDefaultAsync(a => a.Id == id);
            if(domainResponse == null)
            {
                return new BaseResponse() { Message = "Not Found", StatusCode = System.Net.HttpStatusCode.NotFound};
            }
            var response =_db.WalkDifficulty.Remove(domainResponse);
            await _db.SaveChangesAsync();
            return new BaseResponse() { Message = "Deleted Successfully", StatusCode = System.Net.HttpStatusCode.OK };
        }

        public async Task<BaseResponse> GetAllWalkDifficultyAsync()
        {
          var walkdifficultyDomain =  await  _db.WalkDifficulty.ToListAsync();
           var response =  _mapper.Map<List<WalkDifficultyResponse>>(walkdifficultyDomain);
            return new BaseResponse() { Message = "success", StatusCode = System.Net.HttpStatusCode.OK, Data = response };  
        }

        public async Task<BaseResponse> GetWalkDifficultyById(Guid id)
        {
            var domainModel = await _db.WalkDifficulty.FirstOrDefaultAsync(a => a.Id == id);
            if(domainModel == null)
            {
                return new BaseResponse() { Message = "Wrong Guid", StatusCode = System.Net.HttpStatusCode.NotFound };
            }
            var response=_mapper.Map<WalkDifficultyResponse>(domainModel);
            return new BaseResponse() {Message = "success", StatusCode = System.Net.HttpStatusCode.OK, Data = response };
        }

        public async Task<BaseResponse> UpdateWalkDifficulty(WalkDifficultyUpdateRequest updateRequest, Guid id)
        {
           var responseDomain = await _db.WalkDifficulty.FirstOrDefaultAsync(a => a.Id == id);
            if(responseDomain == null)
            {
                return new BaseResponse() { Message="not found", StatusCode=System.Net.HttpStatusCode.NotFound };
            }
            responseDomain.Code = updateRequest.Code;
            await _db.SaveChangesAsync();
            return new BaseResponse() { Message = "updated", StatusCode = System.Net.HttpStatusCode.OK };

        }
    }
}
