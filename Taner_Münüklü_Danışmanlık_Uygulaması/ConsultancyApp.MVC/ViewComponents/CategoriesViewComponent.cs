using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultancyApp.MVC.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryManager;

        public CategoriesViewComponent(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            CategoryListViewModel categoryListViewModel = new CategoryListViewModel();
            if (RouteData.Values["categoryurl"]!= null)
            {
                categoryListViewModel.SelectedCategoryUrl = RouteData.Values["categoryurl"].ToString();
            }
            else
            {
                categoryListViewModel.SelectedCategoryUrl = "";
            }
            List<Category> categories = await _categoryManager.GetAllAsync();
            List<CategoryViewModel> categoryViewModelList = categories
                .Select(c => new CategoryViewModel
                {
                    Name = c.Name,
                    Url = c.Url
                }).ToList();

            categoryListViewModel.CategoryViewModelList = categoryViewModelList;

            return View(categoryListViewModel);
        }
    }
}
