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
    public interface ICourseService
    {
        #region Generic
        Task<Response<CourseDto>> GetByIdAsync(int id);
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto);
        Task<Response<NoContent>> DeleteAsync(int id);
        #endregion

        #region Course
        Task<Response<CourseDto>> GetCoursesByIdAsync(int id);
        Task<Response<List<CourseDto>>> GetCoursesWithFullDataAsync(bool? isActive = null);
        Task<Response<List<CourseDto>>> GetAllActiveCoursesAsync(string categoryUrl = null, string traineeUrl = null, string trainerUrl = null);
        Task<Response<CourseDto>> GetCourseByUrlAsync(string courseUrl);
        Task<Response<List<CourseDto>>> GetCoursesByCategoryAsync(int categoryId);


        Task<Response<List<CourseDto>>> GetAllCoursesWithTrainerAndTrainee(bool isDeleted);

        Task CreateCourseAsync(Course course, List<int> SelectedCategoryIds);
        Task UpdateTrainerOfCourses();

        Task CheckCoursesCategories();
        void UpdateCourse(Course course);


        #endregion
    }
}
