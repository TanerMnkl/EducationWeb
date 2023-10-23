using EgitimApp.Business.Abstract;
using EgitimApp.Shared.ControllerBases;
using EgitimApp.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EgitimUygulaması.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomControllerBase
    {
        private readonly ICategoryService _categoryManager;

        public CategoryController(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetCategories() 
        {
            var response = await _categoryManager.GetAllAsync();
            if (!response.IsSucceeded)
            {
                return NotFound();          
            }
           return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id) 
        {
            var response= await  _categoryManager.GetByIdAsync(id);
            var jsonResult=JsonSerializer.Serialize(response);
            return Ok(jsonResult);


        }

        [HttpPost]
        [Route("/api/[controller]/SaveCategory")]
        public async Task<IActionResult> CreateCategory(CategoryCreateDto categoryCreateDto)
        {
            var response= await _categoryManager.CreateAsync(categoryCreateDto);
            return CreateActionResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDto categoryUpdateDto) 
        {
            var response= await _categoryManager.UpdateAsync(categoryUpdateDto);    
            return Ok(response);
        
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id) 
        {
            var response= await _categoryManager.DeleteAsync(id);
            return Ok(response);
        
        }

       
    
    }
}
