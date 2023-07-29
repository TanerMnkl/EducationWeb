using ConsultancyApp.Data.Abstract;
using ConsultancyApp.Data.Concrete.EfCore.Contexts;
using ConsultancyApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreLessonRepository : EfCoreGenericRepository<Lesson>, ILessonRepository
    {
        ConsultancyAppContext _context = new ConsultancyAppContext();

        public Task CheckLessonsCategories()
        {
            throw new NotImplementedException();
        }

        public async Task CreateLessonAsync(Lesson lesson, List<int> SelectedCategoryIds)
        {
            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
            lesson.CategoriesLessons = SelectedCategoryIds.Select(sc => new CategoriesLessons
            {
                LessonId = lesson.Id,
                CategoryId = sc
            }).ToList();
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Lesson>> GetAllActiveLessonsAsync(string categoryUrl = null, string agencyUrl = null)
        {
            var result = _context
                .Lessons
                .Where(l => l.IsActive && !l.IsDeleted)
                .Include(l => l.Agency)
                .AsQueryable();
            if (categoryUrl!=null)
            {
                result = result
                    .Include(l => l.CategoriesLessons)
                    .ThenInclude(lc => lc.Category)
                    .Where(l => l.CategoriesLessons.Any(lc => lc.Category.Url == categoryUrl))
                    .AsQueryable();
                
            }
            if (agencyUrl!=null)
            {
                result = result
                    .Where(a => a.Agency.Url == agencyUrl)
                    .AsQueryable();
                
            }
            return await result.ToListAsync();


        }

        public async Task<List<Lesson>> GetAllLessonsWithAgency(bool isDeleted)
        {
            var result = await _context
                .Lessons
                .Where(l => l.IsDeleted == isDeleted)
                .Include(l => l.Agency)
                .ToListAsync();
            return result;
        }

        public async Task<List<Lesson>> GetHomePageLessonsAsync()
        {
            var result = await _context
                .Lessons
                .Where(l => l.IsActive && !l.IsDeleted)
                .Include(l => l.CategoriesLessons)
                .ThenInclude(l => l.Category)
                .Include(l => l.Agency)
                .ToListAsync();
            return result;
        }

        public async Task<Lesson> GetLessonByIdAsync(int id)
        {
            var result = await _context
                 .Lessons
                 .Where(l => l.IsActive && !l.IsDeleted && l.Id == id)
                 .Include(l => l.CategoriesLessons)
                 .ThenInclude(cl => cl.Category)
                 .Include(l => l.Agency)
                 .FirstOrDefaultAsync();
            return result;
        }

        public async Task<Lesson> GetLessonByUrlAsync(string lessonUrl)
        {
            var result = await _context
                 .Lessons
                 .Where(l => l.IsActive && !l.IsDeleted && l.Url == lessonUrl)
                 .Include(l => l.CategoriesLessons)
                 .ThenInclude(lc => lc.Category)
                 .Include(l => l.Agency)
                 .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Lesson>> GetLessonsWithFullDataAsync(bool? isActive = null)
        {
            var result = _context
                .Lessons
                .Where(l => !l.IsDeleted)
                .AsQueryable();

            if (isActive==null)
            {
                result = result
                    .Where(l => l.IsActive == isActive)
                    .AsQueryable();

            }

            result = result
                .Include(l => l.CategoriesLessons)
                .ThenInclude(cl => cl.Category)
                .Include(l => l.Agency)
                .AsQueryable();

            return await result.ToListAsync();
        }

        public async Task UpdateAgencyAsync()
        {
            var lessons = await _context
                .Lessons
                .Where(l => l.AgenciesId == null)
                .ToListAsync();

            foreach (var lesson in lessons)
            {
                lesson.AgenciesId = 1;
            };
            _context.Lessons.UpdateRange(lessons);
            await _context.SaveChangesAsync();
        }
    }
}
