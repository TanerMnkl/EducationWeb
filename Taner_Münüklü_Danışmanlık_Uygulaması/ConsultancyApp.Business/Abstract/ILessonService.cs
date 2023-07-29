using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Business.Abstract
{
    public interface ILessonService
    {
        #region Generic
        Task<Lesson> GetByIdAsync(int id);
        Task<List<Lesson>> GetAllAsync();
        Task CreateAsync(Lesson lesson);
        void Update(Lesson lesson);
        void Delete(Lesson lesson);
        #endregion

        #region Lesson
        Task<List<Lesson>> GetHomePageLessonsAsync();
        Task<List<Lesson>> GetAllActiveLessonsAsync(string categoryUrl = null, string agencyUrl = null);

        Task<Lesson> GetLessonByUrlAsync(string lessonUrl);
        Task<Lesson> GetLessonByIdAsync(int id);
        Task<List<Lesson>> GetAllLessonsWithAgency(bool isDeleted);
        Task CreateLessonAsync(Lesson lesson, List<int> SelectedCategoryIds);

        Task<List<Lesson>> GetLessonsWithFullDataAsync(bool? isActive = null);
        Task UpdateAgencyAsync();
        Task CheckLessonsCategories();

        #endregion
    }
}
