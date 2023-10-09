using EgitimApp.Business.Abstract;
using EgitimApp.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgitimUygulaması.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerManager;

        public TrainerController(ITrainerService trainerManager)
        {
            _trainerManager = trainerManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetTrainers() 
        {
            var response = await _trainerManager.GetAllAsync();
            return Ok(response);    
        
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetTrainersById(int id) 
        {
            var response = await _trainerManager.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("/api/[controller]/SaveTrainer")]
        public async Task<IActionResult> CreateTrainer(TrainerCreateDto trainerCreateDto)
        {
            var response= await _trainerManager.CreateAsync(trainerCreateDto);
            return Ok(response);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateTrainer(TrainerUpdateDto trainerUpdateDto)
        {
            var response = await _trainerManager.UpdateAsync(trainerUpdateDto);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletedTrainer(int id) 
        {
            var response = await _trainerManager.DeleteAsync(id);
            return Ok(response);
        
        
        }

    }
}
