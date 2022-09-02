using EmreAydogduoglu.Business.Abstract;
using EmreAydogduoglu.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmreAydogduoglu.UI.ViewComponents
{
    public class ProjectListViewComponent : ViewComponent
    {
        private IProjectService _projectService;

        public ProjectListViewComponent(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public IViewComponentResult Invoke()
        {
            var model = new ProjectListViewModel
            {
                Projects = _projectService.GetProjects()
            };
            return View(model);
        }
    }
}
