using AspNetCoreHero.ToastNotification.Abstractions;
using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Core;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace ConsultancyApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LessonController : Controller
    {

        private readonly ILessonService _lessonManager;
        private readonly IAgencyService _agencyManager;
        private readonly ICategoryService _categoryManager;
        private readonly INotyfService _notfy;

        public LessonController(ILessonService lessonManager, IAgencyService agencyManager, ICategoryService categoryManager, INotyfService notfy)
        {
            _lessonManager = lessonManager;
            _agencyManager = agencyManager;
            _categoryManager = categoryManager;
            _notfy = notfy;
        }



        #region Listeleme

        public async Task<IActionResult> Index()
        {
            List<Lesson> lessonList = await _lessonManager.GetAllLessonsWithAgency(false);
            List<LessonViewModel> lessonViewModelList = lessonList.Select(l => new LessonViewModel
            {
                Id = l.Id,
                Name = l.Name,
                About = l.About,
                IsActive = l.IsActive,
                Kontenjan = l.Kontenjan,
                PeriodOfStudy = l.PeriodOfStudy,
                Price = l.Price,
                AgencyName = l.Agency.Name,
                ImageUrl = l.ImageUrl,
                Url = l.Url,
                ModifiedDate = l.ModifiedDate,
                CreatedDate = l.CreatedDate,


            }).ToList();
            LessonListViewModel model = new LessonListViewModel
            {
                LessonViewModelList = lessonViewModelList,
                SourceAction = "Index"
            };
            return View(model);


        }

        #endregion

        #region Yardımcı metotar(action olmayanlar)
        [NonAction]
        private async Task<List<SelectListItem>> GetAgencySelectList()
        {
            List<Agencies> agencyList = await _agencyManager.GetAllAgenciesAsync(false, true);
            List<SelectListItem> agencyViewModelList = agencyList.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();
            return agencyViewModelList;
        }

        [NonAction]

        private async Task<List<CategoryViewModel>> GetCategoryList()
        {
            List<Category> categoryList = await _categoryManager.GetAllCategoriesAsync(false, true);
            List<CategoryViewModel> categoryViewModelList = categoryList.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return categoryViewModelList;
        }

        [NonAction]
        private List<SelectListItem> GetYearList(int startYear, int endYear)
        {
            List<int> years = Jobs.GetYears(startYear, endYear);
            List<SelectListItem> yearList = years.Select(y => new SelectListItem
            {
                Value = y.ToString(),
                Text = y.ToString()
            }).ToList();
            return yearList;
        }





        #endregion


        #region Yeni Ders

        [HttpGet]

        public async Task<IActionResult> Create()
        {
            var agencyViewModelList = await GetAgencySelectList();
            var categoryViewModelList = await GetCategoryList();
            var yearList = GetYearList(1900, DateTime.Now.Year);
            LessonAddViewModel lessonAddViewModel = new LessonAddViewModel
            {
                AgencyList = agencyViewModelList,
                CategoryList = categoryViewModelList,
                YearList = yearList
            };
            return View(lessonAddViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Create(LessonAddViewModel lessonAddViewModel)
        {

            if (ModelState.IsValid && lessonAddViewModel.SelectedCategoryIds.Count > 0)
            {
                var url = Jobs.GetUrl(lessonAddViewModel.Name);

                Lesson lesson = new Lesson
                {
                    Name = lessonAddViewModel.Name,
                    About = lessonAddViewModel.About,
                    Kontenjan = lessonAddViewModel.Kontenjan,
                    PeriodOfStudy = lessonAddViewModel.PeriodOfStudy,
                    Price = lessonAddViewModel.Price,
                    AgenciesId = lessonAddViewModel.AgencyId,
                    ModifiedDate = lessonAddViewModel.ModifiedDate,
                    CreatedDate = DateTime.Now,

                    Url = url,
                    ImageUrl = Jobs.UploadImage(lessonAddViewModel.ImageFile, url, "lessons"),
                    IsActive = lessonAddViewModel.IsActive
                };
                await _lessonManager.CreateLessonAsync(lesson, lessonAddViewModel.SelectedCategoryIds);
                



                return RedirectToAction("Index");


            }
            if (lessonAddViewModel.SelectedCategoryIds.Count == 0)
            {
                ViewBag.CategoryErrorMessage = "En az bir kategori seçilmelidir";

            }
            var agencyViewModelList = await GetAgencySelectList();
            var categoryViewModelList = await GetCategoryList();
            var yearList = GetYearList(1900, DateTime.Now.Year);
            lessonAddViewModel.AgencyList = agencyViewModelList;
            lessonAddViewModel.YearList = yearList;
            lessonAddViewModel.CategoryList = categoryViewModelList;
            return View(lessonAddViewModel);
        }



        #endregion


        #region Kitap Güncelleme
        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            Lesson lesson = await _lessonManager.GetLessonByIdAsync(id);
            if (lesson == null) { return NotFound(); }

            LessonEditViewModel lessonEditViewModel = new LessonEditViewModel
            {

                Id = lesson.Id,
                Name = lesson.Name,
                Price = lesson.Price,
                About = lesson.About,
                Kontenjan = lesson.Kontenjan,
                IsActive = lesson.IsActive,
                ImageUrl = lesson.ImageUrl,
                IsDeleted = lesson.IsDeleted,
                AgencyId = lesson.AgenciesId,
                SelectedCategoryIds = lesson.CategoriesLessons.Select(lc => lc.CategoryId).ToList(),
                AgencyList = await GetAgencySelectList(),
                CategoryList = await GetCategoryList(),
                YearList = GetYearList(1900, DateTime.Now.Year)



            };

            return View(lessonEditViewModel);
        }


        [HttpPost]

        public async Task<IActionResult> Edit(LessonEditViewModel lessonEditViewModel)
        {

            var url = Jobs.GetUrl(lessonEditViewModel.Name);

            if (ModelState.IsValid && lessonEditViewModel.SelectedCategoryIds.Count > 0)
            {
                Lesson lesson = await _lessonManager.GetLessonByIdAsync(lessonEditViewModel.Id);
                lesson.Name = lessonEditViewModel.Name;
                lesson.About = lessonEditViewModel.About;
                lesson.Kontenjan = lessonEditViewModel.Kontenjan;
                lesson.PeriodOfStudy = lessonEditViewModel.PeriodOfStudy;
                lesson.AgenciesId = lessonEditViewModel.AgencyId;


                lesson.Price = lessonEditViewModel.Price;
                lessonEditViewModel.Url = Jobs.GetUrl(lessonEditViewModel.Name);
                lesson.Url = lessonEditViewModel.Url;
                lesson.IsActive = lessonEditViewModel.IsActive;
                lesson.ModifiedDate = DateTime.Now;
                lesson.IsDeleted = lessonEditViewModel.IsDeleted;
                lesson.CategoriesLessons = lessonEditViewModel.SelectedCategoryIds.Select(lc => new CategoriesLessons
                {
                    LessonId = lesson.Id,
                    CategoryId = lc
                }).ToList();
                lesson.ImageUrl = lessonEditViewModel.ImageFile == null ? lessonEditViewModel.ImageUrl : Jobs.UploadImage(lessonEditViewModel.ImageFile, url, "lessons");

                _lessonManager.Update(lesson);
                return RedirectToAction("Index");

            }

            var agencyViewModelList = await GetAgencySelectList();
            var categoryViewModelList = await GetCategoryList();
            var yearList = GetYearList(1900, DateTime.Now.Year);
            lessonEditViewModel.YearList = yearList;
            lessonEditViewModel.AgencyList = agencyViewModelList;
            lessonEditViewModel.CategoryList = categoryViewModelList;


            return View(lessonEditViewModel);

        }


        public async Task<IActionResult> UpdateIsActive(int id)
        {
            Lesson lesson = await _lessonManager.GetByIdAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            lesson.IsActive = !lesson.IsActive;
            lesson.ModifiedDate = DateTime.Now;
            _lessonManager.Update(lesson);
            string isActive = lesson.IsActive ? "Aktif" : "Pasif";

            return RedirectToAction("Index");
        }


        #endregion

        #region kitap kalıcı silme
        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            Lesson lesson = await _lessonManager.GetLessonByIdAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            LessonDeleteViewModel lessonDeleteViewModel = new LessonDeleteViewModel
            {
                Id = lesson.Id,
                Name = lesson.Name,
                About = lesson.About,
                Price = lesson.Price,
                IsActive = lesson.IsActive,
                Kontenjan = lesson.Kontenjan,
                PeriodOfStudy = lesson.PeriodOfStudy,
                AgencyName = lesson.Agency.Name,



            };
            return View(lessonDeleteViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            Lesson lesson = await _lessonManager.GetByIdAsync(id);
            if (lesson == null) return NotFound();
            _lessonManager.Delete(lesson);
            return RedirectToAction("Index");
        }

        #endregion




        #region Ders Soft Silme

        public async Task<IActionResult> SoftDelete(int id)
        {
            Lesson lesson = await _lessonManager.GetByIdAsync(id);
            if (lesson == null) return NotFound();
            lesson.IsDeleted = !lesson.IsDeleted;
            lesson.ModifiedDate = DateTime.Now;
            _lessonManager.Update(lesson);
            string message = lesson.IsDeleted ? "Kayıt silinmiştir. Geri almak için ilgili bölüme geçiniz." : "Kayıt geri alınmıştır.";
            _notfy.Success(message);
            
            
            return lesson.IsDeleted ? RedirectToAction("Index") : RedirectToAction("DeletedIndex");
        }


        #endregion

        #region Silinmiş dersleri listeleme
        public async Task<IActionResult> DeletedIndex()
        {
            List<Lesson> lesson = await _lessonManager.GetAllLessonsWithAgency(true);
            List<LessonViewModel> lessonViewModelList = lesson
                .Select(l => new LessonViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    About = l.About,
                    Price = l.Price,
                    IsActive = l.IsActive,
                    Kontenjan = l.Kontenjan,
                    PeriodOfStudy = l.PeriodOfStudy,
                    AgencyName = l.Agency.Name,
                }).ToList();
            LessonListViewModel model = new LessonListViewModel
            {
                LessonViewModelList = lessonViewModelList,
                SourceAction = "DeletedIndex"
            };
            return View("Index", model);
        }



        #endregion

    }
}
