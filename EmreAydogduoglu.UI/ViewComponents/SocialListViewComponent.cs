using EmreAydogduoglu.Business.Abstract;
using EmreAydogduoglu.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmreAydogduoglu.UI.ViewComponents
{
    public class SocialListViewComponent : ViewComponent
    {
        private ISocialService _socialService;

        public SocialListViewComponent(ISocialService socialService)
        {
            _socialService = socialService;
        }

        public IViewComponentResult Invoke()
        {
            SocialListViewModel model = new SocialListViewModel
            {
                Socials = _socialService.GetSocials()
            };
            return View(model);
        }
    }
}
