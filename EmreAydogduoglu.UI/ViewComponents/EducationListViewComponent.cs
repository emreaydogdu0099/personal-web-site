using EmreAydogduoglu.Business.Abstract;
using EmreAydogduoglu.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmreAydogduoglu.UI.ViewComponents
{
    public class EducationListViewComponent : ViewComponent
    {
        private IEducationService _educationService;

        public EducationListViewComponent(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public IViewComponentResult Invoke()
        {
            EducationListViewModel model = new EducationListViewModel
            {
                Educations = _educationService.GetEducations()
            };
            return View(model);
    }
}
}
