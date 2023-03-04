using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repository;

namespace NZWalksAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WalkDifficultyController : ControllerBase
    {
        private readonly IWalkDifficultyRepository _walkDifficulty;
        public WalkDifficultyController(IWalkDifficultyRepository walkDifficulty)
        {
            _walkDifficulty = walkDifficulty;

        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var response = await _walkDifficulty.GetAllWalkDifficultyAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetWalkDifficultyById(Guid id)
        {
            var response = await _walkDifficulty.GetWalkDifficultyById(id);
            return Ok(response);
        }

        [HttpPost]

        public async Task<IActionResult> CreateWalkDificulty(WalkDifficultyAddRequest difficultyAddRequest)
        {
            var response = await _walkDifficulty.AddWalkDifficulty(difficultyAddRequest);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteWalkDifficulty(Guid id)
        {
           var response = await _walkDifficulty.DeleteWalkDifficulty(id);
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateWalkdifficulty(WalkDifficultyUpdateRequest updateRequest,Guid id)
        {
            var response =await _walkDifficulty.UpdateWalkDifficulty(updateRequest,id);
            return Ok(response);
        }

    }
}