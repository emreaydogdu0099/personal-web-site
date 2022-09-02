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
    public class SocialController : Controller
    {
        private readonly ISocialService _socialService;

        public SocialController(ISocialService socialService)
        {
            _socialService = socialService;
        }

        public IActionResult Index()
        {
            var model = new SocialListViewModel
            {
                Socials = _socialService.GetSocials()
            };
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Social social)
        {
            if (ModelState.IsValid)
            {
                _socialService.Add(social);
                TempData["success"] = "İletişim adresi başarıyla eklendi.";
                return RedirectToAction("Index","Social",new {area="Admin"});
            }
            TempData["error"] = "Bir hata oluştu!";
            return View();
        }
        public IActionResult Update(int id)
        {
            var social = new SocialViewModel
            {
                Social = _socialService.GetById(id)
            };
            return View(social);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Social social)
        {
            if (ModelState.IsValid)
            {
                _socialService.Update(social);
                TempData["success"] = "İletişim adresi başarıyla güncellendi.";
                return RedirectToAction("Index", "Social", new { area = "Admin" });
            }
            TempData["error"] = "Bir hata oluştu!";
            return View();
        }
        public IActionResult Delete(int id)
        {
            if (id!=null || id!=0)
            {
                var social = _socialService.GetById(id);
                _socialService.Delete(social);
                TempData["success"] = "İletişim adresi başarıyla silindi.";
                return RedirectToAction("Index", "Social", new { area = "Admin" });
            }
            TempData["error"] = "Bir hata oluştu!";
            return RedirectToAction("Index", "Social", new { area = "Admin" });
        }
        

    }
}
