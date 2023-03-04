using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using System.Collections.Generic;
using System.Net;

namespace NZWalksAPI.Repository
{
    public class RegionsRespository : IRegionsRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public RegionsRespository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db; 
            _mapper = mapper;
        }

        public async Task<BaseResponse> AddRegionAsync([FromBody]RegionAddRequest regionAddRequest)
        {
           
            var regionDomain =_mapper.Map<Region>(regionAddRequest);
            regionDomain.Id = Guid.NewGuid();
           var region =  await _db.Regions.AddAsync(regionDomain);
            await _db.SaveChangesAsync();

            var regionResponse = new RegionResponse()
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                Area = regionDomain.Area,
                Lat = regionDomain.Lat,
                Long = regionDomain.Long,
                Population = regionDomain.Population,
            };
           
          
            return new BaseResponse() { Message = "Created", StatusCode = HttpStatusCode.Created, Data = regionResponse};

        }

        public async Task<BaseResponse> DeleteRegionAsync(Guid id)
        {
            var region= await _db.Regions.FirstOrDefaultAsync(u => u.Id == id);
            if(region==null)
            {
                return new BaseResponse() { Message = "Wrong Id", StatusCode = HttpStatusCode.NotFound};
            }
            _db.Regions.Remove(region);
            await _db.SaveChangesAsync();
            return new BaseResponse() { Message = "Deleted", StatusCode = HttpStatusCode.NoContent};
        }

        public async Task<BaseResponse> GetAllRegionsAsync()
        {
            IEnumerable<Region> regions = await _db.Regions.ToListAsync();
            var regionsResponse=_mapper.Map<List<RegionResponse>>(regions);


            
            return new BaseResponse() { Message = "Success", StatusCode = HttpStatusCode.OK, Data = regionsResponse};
        }

        public async Task<BaseResponse> GetRegionByIdAsync(Guid id)
        {
            var regionDomain = await _db.Regions.FirstOrDefaultAsync(u => u.Id == id);
            if(regionDomain == null)
            {
                return new BaseResponse() { Message = "Wrong Guid", StatusCode = HttpStatusCode.BadRequest};
            }
           var regionResponse = _mapper.Map<RegionResponse>(regionDomain);
            return new BaseResponse() { Message = "Success", StatusCode = HttpStatusCode.OK, Data = regionResponse };

        }

        public async Task<BaseResponse> UpdateRegionAsync([FromBody]RegionUpdateRequest regionUpdateRequest, [FromRoute]Guid id)
        {
            var domainRegion = await _db.Regions.FirstOrDefaultAsync(a => a.Id == id);
           
            if(domainRegion == null)
            {
                return new BaseResponse() { Message="Not Found"};
            }
            domainRegion.Code = regionUpdateRequest.Code;
            domainRegion.Name = regionUpdateRequest.Name;
            domainRegion.Area = regionUpdateRequest.Area;
            domainRegion.Lat = regionUpdateRequest.Lat;
            domainRegion.Long = regionUpdateRequest.Long;
            domainRegion.Population = regionUpdateRequest.Population;
            await _db.SaveChangesAsync();
   
           RegionResponse region = _mapper.Map<RegionResponse>(domainRegion);

            return new BaseResponse() { Message = "Updated", StatusCode = HttpStatusCode.OK , Data = region};

          
        }
    }
}
