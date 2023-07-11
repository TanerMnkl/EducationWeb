using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConsultancyApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILessonService _lessonManager;

        public HomeController(ILessonService lessonManager)
        {
            _lessonManager = lessonManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Lesson> lessonList = await _lessonManager.GetHomePageLessonsAsync();

            List<LessonViewModel> lessonViewModelList = lessonList
                .Select(l => new LessonViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Price = l.Price,
                    ImageUrl = l.ImageUrl,
                    AgencyName = l.Agency.Name,
                    Kontejan = l.Kontenjan,
                    PeriodOfStudy = l.PeriodOfStudy
                }).ToList();
            return View(lessonViewModelList);
        }

     
    }
}