using EmreAydogduoglu.Business.Abstract;
using EmreAydogduoglu.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmreAydogduoglu.UI.ViewComponents
{
    public class CvDownloadViewComponent : ViewComponent
    {
        private IPersonService _personService;

        public CvDownloadViewComponent(IPersonService personService)
        {
            _personService = personService;
        }

        public IViewComponentResult Invoke()
        {
            PersonViewModel model = new PersonViewModel
            {
                Person = _personService.GetPerson(1)
            };
            return View(model);
        }
    }
}
