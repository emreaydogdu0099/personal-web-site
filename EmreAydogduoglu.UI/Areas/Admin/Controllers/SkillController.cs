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
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public IActionResult Index()
        {
            var model = new SkillListViewModel
            {
                Skills = _skillService.GetSkills()
            };
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Skill skill)
        {
            if (ModelState.IsValid)
            {
                _skillService.Add(skill);
                TempData["success"] = "Beceri başarıyla eklendi.";
                return RedirectToAction("Index", "Skill", new { area = "Admin" });
            }
            TempData["error"] = "Bir hata oluştu.";
            return View();
        }
        public IActionResult Update(int id)
        {
            var model = new SkillViewModel
            {
                Skill = _skillService.GetById(id)
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Skill skill)
        {
            if (ModelState.IsValid)
            {
                _skillService.Update(skill);
                TempData["success"] = "Beceri başarıyla güncellendi.";
                return RedirectToAction("Index", "Skill", new { area = "Admin" });
            }
            TempData["error"] = "Bir hata oluştu.";
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id!=null || id==0)
            {
                var skill = _skillService.GetById(id);
                _skillService.Delete(skill);
                TempData["success"] = "Beceri başarıyla silindi.";
                return RedirectToAction("Index", "Skill", new { area = "Admin" });
            }
            TempData["error"] = "Bir hata oluştu.";
            return RedirectToAction("Index", "Skill", new { area = "Admin" });
        }
    }
}
