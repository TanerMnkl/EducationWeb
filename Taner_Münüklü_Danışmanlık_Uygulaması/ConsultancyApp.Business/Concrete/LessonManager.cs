using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Data.Abstract;
using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Business.Concrete
{
    public class LessonManager : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonManager(ILessonRepository lessonManager)
        {
            _lessonRepository = lessonManager;
        }

        public async Task CreateAsync(Lesson lesson)
        {
            await _lessonRepository.CreateAsync(lesson);
        }

        public void Delete(Lesson lesson)
        {
            _lessonRepository.Delete(lesson);
        }

        public async Task<List<Lesson>> GetAllAsync()
        {
            var result = await _lessonRepository.GetAllAsync();
            return result;
        }

        public async Task<Lesson> GetByIdAsync(int id)
        {
            var result = await _lessonRepository.GetByIdAsync(id);
            return result;
        }

        public void Update(Lesson lesson)
        {
            _lessonRepository.Update(lesson);
        }

        public async Task<List<Lesson>> GetHomePageLessonsAsync()
        {
            var result = await _lessonRepository.GetHomePageLessonsAsync();
            return result;
        }

        public async Task<List<Lesson>> GetAllActiveLessonsAsync(string categoryUrl = null, string agencyUrl = null)
        {
            var result = await _lessonRepository.GetAllActiveLessonsAsync(categoryUrl, agencyUrl);
            return result;
        }

        public async Task<Lesson> GetLessonByUrlAsync(string lessonUrl)
        {
            var result = await _lessonRepository.GetLessonByUrlAsync(lessonUrl);
            return result;
        }
    }
}
