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
    public class ProjectController : Controller
    {
        private IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            var model = new ProjectListViewModel
            {
                Projects = _projectService.GetProjects()
            };
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Project project)
        {
            if (ModelState.IsValid)
            {
                _projectService.Add(project);
                TempData["success"] = "Proje başarıyla eklendi.";
                return RedirectToAction("Index", "Project", new { area = "Admin" });
            }
            TempData["error"] = "Bir hata oluştu!";
            return View();
        }
        public IActionResult Update(int id)
        {
            var model = new ProjectViewModel
            {
                Project = _projectService.GetById(id)
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Project project)
        {
            if (ModelState.IsValid)
            {
                _projectService.Update(project);
                TempData["success"] = "Proje başarıyla güncellendi.";
                return RedirectToAction("Index", "Project", new { area = "Admin" });
            }
            TempData["error"] = "Bir hata oluştu!";
            return View();
        }
        public IActionResult Delete(int id)
        {
            if (id!=null || id==0)
            {
                var project = _projectService.GetById(id);
                _projectService.Delete(project);
                TempData["success"] = "Proje başarıyla silindi.";
                return RedirectToAction("Index", "Project", new { area = "Admin" });
            }
            TempData["error"] = "Bir hata oluştu!";
            return RedirectToAction("Index", "Project", new { area = "Admin" });
        }
    }
}
