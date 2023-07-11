using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultancyApp.MVC.ViewComponents
{
    public class AgenciesViewComponent:ViewComponent
    {
        private readonly IAgencyService _agencyManager;

        public AgenciesViewComponent(IAgencyService agencyManager)
        {
            _agencyManager = agencyManager;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Agencies> agencyList = await _agencyManager.GetAllAsync();
            List<AgencyViewModel> agencyViewModelList = agencyList.Select(a => new AgencyViewModel
            {
                Name = a.Name,
                Url = a.Url

            }).ToList();
            return View(agencyViewModelList);
        }
    }

}
