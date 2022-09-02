using EmreAydogduoglu.Business.Abstract;
using EmreAydogduoglu.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmreAydogduoglu.UI.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index(int? id)
        {
            if (id == null || id == 0)
            {
                ArticleListViewModel model = new ArticleListViewModel
                {
                    Articles = _articleService.GetArticlesByDate()
                };
                return View(model);
            }
            else
            {
                ArticleListViewModel model = new ArticleListViewModel
                {
                    Articles = _articleService.GetArticlesByCategoryId((int)id)
                };
                return View(model);
            }
        }

        public IActionResult Detail(int id)
        {
            var model = new ArticleByIdViewModel
            {
                Article = _articleService.GetArticleById(id)
            };
            return View(model);
        }
    }
}
