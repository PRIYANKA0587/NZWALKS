using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repository;

namespace NZWalksAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        public WalkController(IWalkRepository walkRepository)
        {
            _walkRepository = walkRepository;

        }

        [HttpGet]
         public async Task<IActionResult> GetAll()
        {
            var response = await _walkRepository.GetAllWalksAsync();
            return Ok(response);

        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetWalk(Guid id)
        {
          var response =  await _walkRepository.GetWalkByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> AddWalk([FromBody]WalkAddRequest walkAddRequest)
        {
           var response =  await _walkRepository.AddWalkAsync(walkAddRequest);
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdateWalk([FromBody]WalkUpdateRequest updateRequest, Guid id)
        {
           var response = await _walkRepository.UpdateWalkAsync(updateRequest, id);
            return Ok(response);

        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteWalk(Guid id)
        {
            var response =await _walkRepository.DeleteWalkAsync(id);
            return Ok(response);
        }
    }
}
