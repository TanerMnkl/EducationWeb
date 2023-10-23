using EgitimApp.Entity.Concrete;
using EgitimApp.Shared.DTOs;
using EgitimApp.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Business.Abstract
{
    public interface ICategoryService
    {
        Task<Response<CategoryDto>> GetByIdAsync(int id);
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto);
        Task<Response<NoContent>> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
        Task<Response<NoContent>> DeleteAsync(int id);
    }
}
