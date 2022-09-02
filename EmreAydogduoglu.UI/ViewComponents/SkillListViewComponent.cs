using EmreAydogduoglu.Data.Abstract;
using EmreAydogduoglu.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmreAydogduoglu.UI.ViewComponents
{
    public class SkillListViewComponent : ViewComponent
    {
        private ISkillDal _skillDal;

        public SkillListViewComponent(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public IViewComponentResult Invoke()
        {
            SkillListViewModel model = new SkillListViewModel
            {
                Skills = _skillDal.GetAll()
            };
            return View(model);
        }
    }
}
