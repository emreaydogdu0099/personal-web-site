using EmreAydogduoglu.Business.Abstract;
using EmreAydogduoglu.Entities.Concrete;
using EmreAydogduoglu.UI.Areas.Admin.Models;
using EmreAydogduoglu.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmreAydogduoglu.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            CategoryListViewModel model = new CategoryListViewModel
            {
                Categories = _categoryService.GetCategories()
            };
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Add(Category category)
        {
            _categoryService.Add(category);
            TempData["success"] = "Kategori başarıyla eklendi.";
            return RedirectToAction("Index", "Category", new { area = "Admin" });

        }
        public IActionResult Update(int id)
        {
            CategoryViewModel model = new CategoryViewModel
            {
                Category = _categoryService.GetCategoryById(id)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category category)
        {
            _categoryService.Update(category);
            TempData["success"] = "Kategori başarıyla güncellendi.";
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            _categoryService.Delete(category);
            TempData["success"] = "Kategori başarıyla silindi.";
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
    }
}
