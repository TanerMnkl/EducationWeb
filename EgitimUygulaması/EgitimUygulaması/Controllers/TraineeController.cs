using EgitimApp.Business.Abstract;
using EgitimApp.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgitimUygulaması.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : ControllerBase
    {
        private readonly ITraineeService _traineeManager;

        public TraineeController(ITraineeService traineeManager)
        {
            _traineeManager = traineeManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrainees()
        {
            var response= await _traineeManager.GetAllAsync();
            return Ok(response);    

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTraineeById(int id)
        {
            var response= await _traineeManager.GetByIdAsync(id);
            return Ok(response);
        }
        [HttpPost]
        [Route("/api/[controller]/SaveTrainee")]
        public async Task<IActionResult> CreateTrainee(TraineeCreateDto traineeCreateDto)
        {
            var response= await _traineeManager.CreateAsync(traineeCreateDto);
            return Ok(response);    
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTrainee(TraineeUpdateDto traineeUpdateDto)
        {
            var response= await _traineeManager.UpdateAsync(traineeUpdateDto);
            return Ok(response);

        }

        [HttpDelete]
        public async Task<IActionResult> DeletedTrainee(int id)
        {
            var response = await _traineeManager.DeleteAsync(id);
            return Ok(response);
        }
    }
}
