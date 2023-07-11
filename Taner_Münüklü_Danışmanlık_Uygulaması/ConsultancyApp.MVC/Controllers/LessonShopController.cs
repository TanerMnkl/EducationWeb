using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultancyApp.MVC.Controllers
{
    public class LessonShopController : Controller
    {
        private readonly ILessonService _lessonManager;

        public LessonShopController(ILessonService lessonManager)
        {
            _lessonManager = lessonManager;
        }


        public async Task<IActionResult> LessonList(string categoryurl=null, string agencyurl=null)
        {
            List<Lesson> lessonList = await _lessonManager.GetAllActiveLessonsAsync(categoryurl, agencyurl);
            List<LessonViewModel> lessonViewModelList = lessonList.Select(l => new LessonViewModel
            {
                Id = l.Id,
                Name = l.Name,
                Price = l.Price,
                Url = l.Url,
                ImageUrl = l.ImageUrl,
                AgencyName = l.Agency.Name,

            }).ToList();
            return View(lessonViewModelList);
        }
    }
}
