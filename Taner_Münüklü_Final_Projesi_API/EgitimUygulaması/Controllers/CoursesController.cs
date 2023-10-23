using EgitimApp.Business.Abstract;
using EgitimApp.Shared.ControllerBases;
using EgitimApp.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgitimUygulaması.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : CustomControllerBase
    {
        private readonly ICourseService _courseManager;

        public CoursesController(ICourseService courseManager)
        {
            _courseManager = courseManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var response = await _courseManager.GetCoursesWithFullDataAsync(true);
            return CreateActionResult(response);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var response = await _courseManager.GetCoursesByIdAsync(id);
            return CreateActionResult(response);

        }

        [HttpPost]
        [Route("/api/[controller]/SaveCourse")]
        public async Task<IActionResult> SaveCourse(CourseCreateDto courseCreateDto)
        {
            var response = await _courseManager.CreateAsync(courseCreateDto);
            return CreateActionResult(response);

        }
        [HttpGet]
        [Route("/api/[controller]/GetCoursesByCategory/{categoryId}")]
        public async Task<IActionResult> GetCoursesByCategory(int categoryId)
        {
            var response = await _courseManager.GetCoursesByCategoryAsync(categoryId);
            return CreateActionResult(response);



        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourse(CourseUpdateDto courseUpdateDto)
        {
            var response = await _courseManager.UpdateAsync(courseUpdateDto);
            return CreateActionResult(response);


        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(int id)

        {
            var response= await _courseManager.DeleteAsync(id); 
            return CreateActionResult(response);
        
        
        }


    }
}
