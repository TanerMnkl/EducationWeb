using AspNetCoreHero.ToastNotification.Abstractions;
using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Core;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultancyApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AgenciesController : Controller
    {
        private readonly IAgencyService _agencyManager;
        

        public AgenciesController(IAgencyService agencyManager)
        {
            _agencyManager = agencyManager;
        }

        #region Listeleme
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Agencies> agencyList = await _agencyManager.GetAllAgenciesAsync(false);
            List<AgencyViewModel> agencyViewModelList = agencyList
                .Select(a => new AgencyViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    About = a.About,
                    IsActive = a.IsActive,
                    Url = a.Url,
                    CreatedDate = a.CreatedDate,
                    ModifiedDate = a.ModifiedDate,
                    FoundationOfYear = a.FoundationYear,


                }).ToList();
            return View(agencyViewModelList);
        }

        #endregion

        #region Yeni yazar
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AgencyAddViewModel agencyAddViewModel)
        {
            if (ModelState.IsValid)
            {
                Agencies agencies = new Agencies
                {
                    Name = agencyAddViewModel.Name,
                    About = agencyAddViewModel.About,
                    FoundationYear = agencyAddViewModel.FoundationOfYear,
                    IsActive = agencyAddViewModel.IsActive,
                    ModifiedDate = DateTime.Now,
                    Url = Jobs.GetUrl(agencyAddViewModel.Name),
                    ImageUrl = "default-profile.jpg",
                    City = "İstanbul"


                };
                await _agencyManager.CreateWithUrl(agencies);

                return RedirectToAction("Index");
            }
            return View();
        }




        #endregion

        #region yazar güncelleme

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Agencies agencies = await _agencyManager.GetByIdAsync(id);
            if (agencies == null)
            {
                return NotFound();

            }
            AgencyEditViewModel agencyEditViewModel = new AgencyEditViewModel
            {
                Id = agencies.Id,
                Name = agencies.Name,
                About = agencies.About,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                FoundationOfYear = agencies.FoundationYear,
                IsActive = agencies.IsActive,
                Url = agencies.Url,
                City=agencies.City
                


            };
            return View(agencyEditViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(AgencyEditViewModel agencyEditViewModel)
        {
            if (ModelState.IsValid)
            {
                Agencies agency = await _agencyManager.GetByIdAsync(agencyEditViewModel.Id);
                if (agency==null)
                {
                    return NotFound();
                }
                agency.Name = agencyEditViewModel.Name;
                agency.About = agencyEditViewModel.About;
                agency.City = agencyEditViewModel.City;
                agency.CreatedDate = agencyEditViewModel.CreatedDate;
                agency.ModifiedDate = agencyEditViewModel.ModifiedDate;
                agency.IsActive = agencyEditViewModel.IsActive;
                agency.Url = Jobs.GetUrl(agencyEditViewModel.Name);
                _agencyManager.Update(agency);
                return RedirectToAction("Index");



            }
            return View(agencyEditViewModel);
        }

        public async Task<IActionResult> UpdateIsActive(int id)
        {
            Agencies agency = await _agencyManager.GetByIdAsync(id);
            if (agency==null)
            {
                return NotFound();
                
            }
            agency.IsActive = !agency.IsActive;
            agency.ModifiedDate = DateTime.Now;
            _agencyManager.Update(agency);
            string isActive = agency.IsActive ? "Aktif" : "Pasif";
            return RedirectToAction("Index");
        }



        #endregion




        #region Yazar kalıcı silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Agencies agency = await _agencyManager.GetByIdAsync(id);
            if (agency == null) return NotFound();
            AgencyDeleteViewModel agencyDeleteViewModel = new AgencyDeleteViewModel
            {
                Id = agency.Id,
                Name = agency.Name,
                About = agency.About,
                City = agency.City,
                Url = agency.Url,
                ImageUrl = agency.ImageUrl,
                FoundationOfYear = agency.FoundationYear,
                CreatedDate = agency.CreatedDate,
                ModifiedDate = agency.ModifiedDate,
                IsActive = agency.IsActive,
                IsDeleted=agency.IsDeleted
                
            };
            return View(agencyDeleteViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id) 
        {
            Agencies agency = await _agencyManager.GetByIdAsync(id);
            if (agency == null) return NotFound();
            _agencyManager.Delete(agency);
            return RedirectToAction("Index");
        }



        #endregion


        #region Yazar soft silme

        public async Task<IActionResult> SoftDelete(int id)
        {
            Agencies agency = await _agencyManager.GetByIdAsync(id);
            if (agency == null) return NotFound();
            agency.IsDeleted = true;
            agency.ModifiedDate = DateTime.Now;
            _agencyManager.Update(agency);
            return RedirectToAction("Index");
        }



        #endregion
    }
}
