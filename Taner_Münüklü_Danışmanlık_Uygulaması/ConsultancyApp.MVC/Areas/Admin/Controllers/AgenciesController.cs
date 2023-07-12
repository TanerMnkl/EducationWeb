using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultancyApp.MVC.Areas.Admin.Controllers
{
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
    }
}
