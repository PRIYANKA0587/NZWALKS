using AutoMapper;
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

        public async Task<BaseResponse> GetAllRegionsAsync()
        {
            IEnumerable<Region> regions = await _db.Regions.ToListAsync();
            var regionsResponse=_mapper.Map<List<RegionResponse>>(regions);


            //List<RegionResponse> regionsResponse = new List<RegionResponse>();
            //regions.ToList().ForEach(regions =>
            //{
            //    var regionDto = new RegionResponse()
            //    {
            //        Id = regions.Id,
            //        Name = regions.Name,
            //        Area = regions.Area,
            //        Code = regions.Code,
            //        Lat = regions.Lat,
            //        Long = regions.Long,
            //        Population = regions.Population,
            //        Walks = regions.Walks
            //    };
            //    regionsResponse.Add(regionDto);
               
            //});
            
               
            
            return new BaseResponse() { Message = "Success", StatusCode = HttpStatusCode.OK, Data = regionsResponse};
        }
    }
}
