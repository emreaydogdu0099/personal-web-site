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
    public class EducationController : Controller
    {
        private IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public IActionResult Index()
        {
            EducationListViewModel model = new EducationListViewModel
            {
                Educations = _educationService.GetEducations()
            };
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Education education)
        {
            if (ModelState.IsValid)
            {
                _educationService.Add(education);
                TempData["success"] = "Eğitim bilgisi başarıyla eklendi.";
                return RedirectToAction("Index","Education",new {area="Admin"});
            }
            TempData["error"] = "Bir hata oluştu!";
            return View();
        }
        public IActionResult Update(int id)
        {
            EducationViewModel model = new EducationViewModel
            {
                Education = _educationService.GetById(id)
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Education education)
        {
            if (ModelState.IsValid)
            {
                _educationService.Update(education);
                TempData["success"] = "Eğitim bilgisi başarıyla güncellendi.";
                return RedirectToAction("Index","Education",new {area = "Admin"});
            }
            TempData["error"] = "Bir hata oluştu!";
            return View();
        }
        public IActionResult Delete(int id)
        {
            if (id!=null || id==0)
            {
                var education = _educationService.GetById(id);
                _educationService.Delete(education);
                TempData["success"] = "Eğitim bilgisi başarıyla silindi.";
                return RedirectToAction("Index","Education",new {area="Admin"});
            }
            TempData["error"] = "Bir hata oluştu!";
            return RedirectToAction("Index", "Education", new { area = "Admin" });
        }
    }
}
