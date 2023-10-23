using EgitimApp.Data.Abstract;
using EgitimApp.Data.Concrete.EfCore.Contexts;
using EgitimApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCourseRepository : EfCoreGenericRepository<Course>, ICourseRepository
    {
        public EfCoreCourseRepository(EducationAppContext _context):base(_context)
        {

        }

        private EducationAppContext Context
        {
            get { return _dbContext as EducationAppContext; }
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await Context
                .Courses
                .AnyAsync(x => x.Id == id);
        }

        public async Task CheckCoursesCategories()
        {
            var courseCategoriesIds= await Context.CoursesCategories.Select(cc=>cc.CourseId).ToListAsync();
            var courseIds= await Context .Courses.Select(c=>c.Id).ToListAsync();
            List<int> different = courseIds.Except(courseCategoriesIds).ToList();
            await Context.CoursesCategories.AddRangeAsync(different.Select(d => new CoursesCategories
            {
                CourseId = d,
                CategoryId = 1
            }).ToList());
            await Context.SaveChangesAsync();
        }

        public Task CreateCourseAsync(Course course, List<int> SelectedCategoryIds)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Course>> GetAllActiveCoursesAsync(string categoryUrl = null, string traineeUrl = null, string trainerUrl = null)
        {
            var result = Context
                .Courses
                .Where(c => c.IsActive && !c.IsDeleted)
                .Include(c => c.Trainer)
                .AsQueryable();
            if (categoryUrl!=null)
            {
                result = result
                    .Include(c => c.CoursesCategories)
                    .ThenInclude(cc => cc.Category)
                    .Where(c => c.CoursesCategories.Any(cc => cc.Category.Url == categoryUrl))
                    .AsQueryable();
            }
            if (traineeUrl!=null)
            {
                result = result
                  .Include(c => c.CoursesTrainees)
                  .ThenInclude(ct => ct.Trainee)
                  .Where(c => c.CoursesTrainees.Any(ct => ct.Trainee.Url == traineeUrl))
                  .AsQueryable();
                
            }
            if (trainerUrl!=null)
            {
                result = result
                   .Where(c => c.Trainer.Url == trainerUrl)
                   .AsQueryable();
            }
            return await result.ToListAsync();

        }

        public async Task<List<Course>> GetAllCoursesWithTrainerAndTrainee(bool isDeleted)
        {
            var result = await Context
                .Courses
                .Where(c => c.IsDeleted == isDeleted)
                 .Include(c => c.CoursesTrainees)
                  .ThenInclude(ct => ct.Trainee)
                .Include(c => c.Trainer)
                .ToListAsync();
            return result;
        }

        public async Task<Course> GetCourseByUrlAsync(string courseUrl)
        {
            var result= await Context
                .Courses
                .Where(c=>c.IsActive && !c.IsDeleted &&c.Url == courseUrl)
                 .Include(c => c.CoursesCategories)
                  .ThenInclude(cc => cc.Category)
                  .Include(c => c.CoursesTrainees)
                  .ThenInclude(ct => ct.Trainee)
                  .Include(c=>c.Trainer)
                  .FirstOrDefaultAsync();
            return result;


        }

        public async Task<List<Course>> GetCoursesByCategoryAsync(int categoryId)
        {
            var result = await Context
                .Courses
                .Where(c => c.IsActive && !c.IsDeleted)
                .Include(c => c.CoursesCategories).ThenInclude(cc => cc.Category)
                .Where(c => c.CoursesCategories.Any(c => c.CategoryId == categoryId))
                .Include(c => c.Trainer)
                .ToListAsync();
            return result; 
        }

        public async Task<Course>GetCoursesByIdAsync(int id)
        {
            var result = await Context
                .Courses
                .Where(c => c.IsActive && !c.IsDeleted && c.Id == id)
                .Include(c => c.CoursesCategories)
                .ThenInclude(cc => cc.Category)
                .Include(c => c.Trainer)
                .FirstOrDefaultAsync();
            return result;

        }

        public async Task<List<Course>> GetCoursesWitFullDataAsync( bool? isActive = null)
        {
            var result = Context
              .Courses
              .Where(b => !b.IsDeleted)
              .AsQueryable();


            if (isActive != null)
            {
                result = result
                    .Where(b => b.IsActive == isActive)
                    .AsQueryable();
            }
            result = result
                .Include(c => c.CoursesCategories)
                  .ThenInclude(cc => cc.Category)
                  .Include(c => c.CoursesTrainees)
                  .ThenInclude(ct => ct.Trainee)
                  .Include(c => c.Trainer)
                  .AsQueryable();
            return await result.ToListAsync();
        }

        public void UpdateCourse(Course course)
        {
            Course oldCourse= Context
                .Courses
                .Include(c => c.CoursesCategories)
                  .ThenInclude(cc => cc.Category)
                  .Include(c => c.CoursesTrainees)
                  .ThenInclude(ct => ct.Trainee)
                  .Include(c => c.Trainer)
                  .Where(c=>c.Id == course.Id)
                  .FirstOrDefault();
            oldCourse.CourseName=course.CourseName;
            oldCourse.About=course.About;
            oldCourse.TotalCourseHour=course.TotalCourseHour;
            oldCourse.TotalCourseMonthly=course.TotalCourseMonthly;
           oldCourse.Url=course.Url;
            oldCourse.AchievementsOfEducation = course.AchievementsOfEducation; 
            oldCourse.EducationContents=course.EducationContents;
            oldCourse.EducationStatus=course.EducationStatus;
            oldCourse.EndTime=course.EndTime;
            oldCourse.StartTime=course.StartTime;
            oldCourse.IsActive=course.IsActive;
            oldCourse.IsDeleted=course.IsDeleted;
            oldCourse.ImageUrl=course.ImageUrl;
            oldCourse.LevelofEducation=course.LevelofEducation;
            oldCourse.LocationofEducation=course.LocationofEducation;
            oldCourse.TrainerId=course.TrainerId;
            oldCourse.Price=course.Price; 
            oldCourse.EducationOfEvaluation=course.EducationOfEvaluation;

            Context.Courses.Update(oldCourse);
            Context.SaveChanges();


        }

      

        public async Task UpdateTrainerOfCourses()
        {
            var courses = await Context
                 .Courses
                 .Where(c => c.TrainerId == null)
                 .ToListAsync();
            foreach (var course in courses)
            {
                course.TrainerId = 1;
            };
            Context.Courses.UpdateRange(courses);
            await Context.SaveChangesAsync();
        }
    }
}
