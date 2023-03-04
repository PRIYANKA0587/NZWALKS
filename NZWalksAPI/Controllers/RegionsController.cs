using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repository;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionsRepository _regionsRepository;

        public RegionsController(IRegionsRepository regionsRepository)
        {
            _regionsRepository = regionsRepository;

        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionsRepository.GetAllRegionsAsync();
            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetId")]

        public async Task<IActionResult> GetById(Guid id)
        {
            
            var regionResponse = await _regionsRepository.GetRegionByIdAsync(id);
            return Ok(regionResponse);
        }

        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> AddRegion(RegionAddRequest regionAddRequest)
        {
            var response = await _regionsRepository.AddRegionAsync(regionAddRequest);

            return Ok(response);          

            
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            var response = await _regionsRepository.DeleteRegionAsync(id);
            return Ok(response);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromBody] RegionUpdateRequest regionUpdate, Guid id)
        {
           var response = await  _regionsRepository.UpdateRegionAsync(regionUpdate, id);
            return Ok(response);

        }
    }
}
