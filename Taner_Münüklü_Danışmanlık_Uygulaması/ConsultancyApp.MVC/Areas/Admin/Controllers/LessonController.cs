using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Core;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultancyApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LessonController : Controller
    {

        private readonly ILessonService _lessonManager;

        public LessonController(ILessonService lessonManager)
        {
            _lessonManager = lessonManager;
        }



        #region Listeleme

        public async Task<IActionResult> Index()
        {
            List<Lesson> lessonList = await _lessonManager.GetAllAsync();
            List<LessonViewModel> lessonViewModelsList = lessonList.Select(l => new LessonViewModel
            {
                Id = l.Id,
                Name = l.Name,
                About = l.About,
                Price = l.Price,
                Kontenjan = l.Kontenjan,
                PeriodOfStudy = l.PeriodOfStudy,
                Url = l.Url,
                ImageUrl = l.ImageUrl,
                ModifiedDate = l.ModifiedDate,
                CreatedDate = l.CreatedDate,
                IsActive = l.IsActive,
                IsDeleted = l.IsDeleted
            }).ToList();
            return View(lessonViewModelsList);
        }

        #endregion


        #region Yeni Ders

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(LessonAddViewModel lessonAddViewModel)
        {
            if (ModelState.IsValid)
            {
                Lesson lesson = new Lesson
                {
                    Name = lessonAddViewModel.Name,
                    About = lessonAddViewModel.About,
                    Kontenjan = lessonAddViewModel.Kontenjan,
                    PeriodOfStudy = lessonAddViewModel.PeriodOfStudy,
                    Price = lessonAddViewModel.Price,
                    Url = Jobs.GetUrl(lessonAddViewModel.Name),
                    ImageUrl = "default-profile.jpg",
                    IsActive = lessonAddViewModel.IsActive
                };
                await _lessonManager.CreateAsync(lesson);

                return RedirectToAction("Index");


            }
            return View(lessonAddViewModel);
        }



        #endregion

    }
}
