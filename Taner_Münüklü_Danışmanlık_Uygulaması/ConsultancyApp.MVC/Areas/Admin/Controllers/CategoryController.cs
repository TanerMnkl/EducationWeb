using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Core;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConsultancyApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryManager;

        public CategoryController(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }

        #region listeleme
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Category> categoryList = await _categoryManager.GetAllCategoriesAsync(false);
            List<CategoryViewModel> categoryViewModelList = categoryList
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.About,
                    CreatedDate = c.CreatedDate,
                    IsActive = c.IsActive,
                    ModifiedDate = c.ModifiedDate,
                    Url = c.Url
                }).ToList();

            return View( categoryViewModelList);
        }


        #endregion


        #region Yeni Kategori
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddViewModel categoryAddViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category
                {
                    Name=categoryAddViewModel.Name,
                    About=categoryAddViewModel.About,
                    IsActive=categoryAddViewModel.IsActive,
                    Url=Jobs.GetUrl(categoryAddViewModel.Name)
                };
                await _categoryManager.CreateAsync(category);
                return RedirectToAction("Index");
                
            }
            return View();
        }

        #endregion



        #region Kategori Güncelleme

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            Category category = await _categoryManager.GetByIdAsync(id);
            if (category==null )
            {
                return NotFound();
            }
            CategoryEditViewModel categoryEditViewModel = new CategoryEditViewModel
            {
                Id = category.Id,
                Name = category.Name,
                About = category.About,
                Url = category.Url,
                IsActive = category.IsActive,
                IsDeleted = category.IsDeleted
            };
            return View(categoryEditViewModel);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(CategoryEditViewModel categoryEditViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = await _categoryManager.GetByIdAsync(categoryEditViewModel.Id);
                category.Name = categoryEditViewModel.Name;
                category.About = categoryEditViewModel.About;
                categoryEditViewModel.Url = Jobs.GetUrl(categoryEditViewModel.Name);
                category.Url = categoryEditViewModel.Url;
                category.IsActive = categoryEditViewModel.IsActive;
                category.IsDeleted = categoryEditViewModel.IsDeleted;
                _categoryManager.Update(category);
                return RedirectToAction("Index");
                
                
            }
            return View();
        }


        #endregion



        #region Kategori kalıcı silme
        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _categoryManager.GetByIdAsync(id);
            if (category == null) return NotFound();
            CategoryDeleteViewModel categoryDeleteViewModel = new CategoryDeleteViewModel
            {
                Id = category.Id,
                Name = category.Name,
                About = category.About,
                IsActive = category.IsActive,
                IsDeleted = category.IsDeleted,
                Url = category.Url,
                CreatedDate = category.CreatedDate,
                ModifiedDate = category.ModifiedDate
            };
            return View(categoryDeleteViewModel);
        }
        [HttpGet]

        public async Task<IActionResult> HardDelete(int id)
        {
            Category category = await _categoryManager.GetByIdAsync(id);
            if (category == null) return NotFound();
            _categoryManager.Delete(category);
            return RedirectToAction("Index");
        }

        #endregion

        #region Kategori soft silme
        public async Task<IActionResult> SoftDelete(int id)
        {
            Category category = await _categoryManager.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            category.IsDeleted = true;
            category.ModifiedDate = DateTime.Now;
            _categoryManager.Update(category);
            return RedirectToAction("Index");
        }


        #endregion


    }
}
