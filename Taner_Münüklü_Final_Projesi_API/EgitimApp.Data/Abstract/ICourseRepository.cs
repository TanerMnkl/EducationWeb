using EgitimApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Data.Abstract
{
    public interface ICourseRepository:IGenericRepository<Course>
    {
        Task<bool> AnyAsync(int id);
        Task<List<Course>> GetCoursesWitFullDataAsync( bool? isActive = null);
        Task<List<Course>> GetAllActiveCoursesAsync(string categoryUrl=null, string traineeUrl= null, string trainerUrl=null);
        Task<Course> GetCourseByUrlAsync(string courseUrl);
        Task<Course> GetCoursesByIdAsync(int id);
        Task<List<Course>> GetCoursesByCategoryAsync(int categoryId);

        Task<List<Course>> GetAllCoursesWithTrainerAndTrainee(bool isDeleted);

        Task CreateCourseAsync(Course course, List<int> SelectedCategoryIds);
        Task UpdateTrainerOfCourses();
       
        Task CheckCoursesCategories();
        void UpdateCourse(Course course);

    }
}
