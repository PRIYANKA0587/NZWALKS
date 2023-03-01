using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
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
        public async  Task<IActionResult> GetAll()
        {
            var regions = await _regionsRepository.GetAllRegionsAsync();
            return Ok(regions);
        }
    }
}
