using EmreAydogduoglu.Business.Abstract;
using EmreAydogduoglu.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmreAydogduoglu.UI.ViewComponents
{
    public class PersonImageViewComponent : ViewComponent
    {
        IPersonService _personService;

        public PersonImageViewComponent(IPersonService personService)
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
