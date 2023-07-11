using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Abstract
{
    public   interface ILessonRepository:IGenericRepository<Lesson>
    {
        Task<List<Lesson>> GetHomePageLessonsAsync();
        Task<List<Lesson>> GetAllActiveLessonsAsync(string categoryUrl = null, string agencyUrl = null);

        Task<Lesson> GetLessonByUrlAsync(string lessonUrl);
    }
}
