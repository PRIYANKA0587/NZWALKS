using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using System.Net;

namespace NZWalksAPI.Repository
{
    public class WalkRepository : IWalkRepository
    {
        private readonly ApplicationDbContext _db;
        
        private readonly IMapper _mapper;
        
        public WalkRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
           
            _mapper = mapper;   

        }
        public async Task<BaseResponse> AddWalkAsync(WalkAddRequest walkAddRequest)
        {
            if (walkAddRequest == null)
            {
                return new BaseResponse(){ Message = "something went wrong", StatusCode = HttpStatusCode.NotFound };
            }
            var walkDomain =_mapper.Map<Walk>(walkAddRequest);
            walkDomain.Id = Guid.NewGuid();
            await _db.Walks.AddAsync(walkDomain);
            return new BaseResponse() { Message = "Created", StatusCode = HttpStatusCode.OK };
        }

        public async Task<BaseResponse> DeleteWalkAsync(Guid id)
        {
           var domainWalk = await _db.Walks.FirstOrDefaultAsync(a => a.Id == id);
            if(domainWalk == null)
            {
                return new BaseResponse() { Message = "id not exists" };
            }
            _db.Walks.Remove(domainWalk);
            await _db.SaveChangesAsync();
            return new BaseResponse()
            {
                Message = "Deleted Successfully", StatusCode=HttpStatusCode.OK
            };
        }

        public async Task<BaseResponse> GetAllWalksAsync()
        {
            IEnumerable<Walk> walkDomain = await _db.Walks.Include(a=>a.Region).Include(a=>a.WalkDifficulty).
                                                ToListAsync();
           var walkResponse =  _mapper.Map<List<WalkResponse>>(walkDomain);
            return new BaseResponse { Message = "Success", StatusCode = HttpStatusCode.OK, Data = walkResponse };
        }

        public async Task<BaseResponse> GetWalkByIdAsync(Guid id)
        {
          var WalkDomain =  await _db.Walks.Include(a=>a.Region).Include(a=>a.WalkDifficulty).FirstOrDefaultAsync(a => a.Id == id);
            if(WalkDomain == null)
            {
                return new BaseResponse() { Message = "Wrong id", StatusCode = HttpStatusCode.NotFound };
            }
           var walkResponse =  _mapper.Map<WalkResponse>(WalkDomain);
            return new BaseResponse() { Message = "Success", StatusCode = HttpStatusCode.OK, Data = walkResponse };
        }

        public async Task<BaseResponse> UpdateWalkAsync(WalkUpdateRequest walkUpdateRequest, Guid id)
        {
            
            if(walkUpdateRequest == null || walkUpdateRequest.Id != id)
            {
                return new BaseResponse() { Message = "id not exists", StatusCode = HttpStatusCode.NotFound };
            }

          var  walkDomain = _mapper.Map<Walk>(walkUpdateRequest);
               var result  =  _db.Walks.Update(walkDomain);
            await _db.SaveChangesAsync();
            
          
            return new BaseResponse() { Message = "Updated", StatusCode = HttpStatusCode.OK};
        }
    }
}
