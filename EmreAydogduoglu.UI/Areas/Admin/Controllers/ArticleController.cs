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
    public class ArticleController : Controller
    {
        private IArticleService _articleService;
        private ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            ArticleListViewModel model = new ArticleListViewModel
            {
                Articles = _articleService.GetArticles()
            };
            return View(model);
        }

        public IActionResult Add()
        {
            ArticleViewModel model = new ArticleViewModel
            {
                Article = new Article(),
                Categories = _categoryService.GetCategories()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Article article, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"assets\img\article");
                var extension = Path.GetExtension(file.FileName);

                if (article.ThumbnailName != null)
                {
                    var oldThumbnail = Path.Combine(wwwRootPath, article.ThumbnailName.TrimStart('\\'));
                    if (System.IO.File.Exists(oldThumbnail))
                    {
                        System.IO.File.Delete(oldThumbnail);
                    }
                }

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }

                article.ThumbnailName = fileName + extension;
            }
            else
            {
                article.ThumbnailName = @"article_default.jpg";
            }

            _articleService.Add(article);
            TempData["success"] = "Makale başarıyla eklendi.";
            return RedirectToAction("Index", "Article", new { area = "Admin" });

        }
        public IActionResult Update(int id)
        {
            ArticleViewModel model = new ArticleViewModel
            {
                Article = _articleService.GetArticleById(id),
                Categories = _categoryService.GetCategories()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Article article, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            article.ThumbnailName = _articleService.GetArticleById(article.Id).ThumbnailName;
            if (file == null)
            {
                article.ThumbnailName = _articleService.GetArticleById(article.Id).ThumbnailName;
            }
            else
            {
                string fileName = Guid.NewGuid().ToString();
                string uploads = Path.Combine(_webHostEnvironment.WebRootPath, @"assets\img\article");
                string extension = Path.GetExtension(file.FileName);

                if (article.ThumbnailName != null)
                {
                    string oldThumbnail = Path.Combine(wwwRootPath, (@"assets\img\article\" + article.ThumbnailName).TrimStart('\\'));
                    if (System.IO.File.Exists(oldThumbnail))
                    {
                        System.IO.File.Delete(oldThumbnail);
                    }
                }

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }

                article.ThumbnailName = fileName + extension;
            }
            _articleService.Update(article);
            TempData["success"] = "Makale başarıyla güncellendi.";
            return RedirectToAction("Index", "Article", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            if (id != null || id != 0)
            {
                var article = _articleService.GetArticleById(id);
                var oldThumbnail = Path.Combine(_webHostEnvironment.WebRootPath, (@"assets\img\article\" + article.ThumbnailName).TrimStart('\\'));
                if (System.IO.File.Exists(oldThumbnail))
                {
                    System.IO.File.Delete(oldThumbnail);
                }
                _articleService.Delete(article);
                TempData["success"] = "Makale başarıyla silindi.";
                return RedirectToAction("Index", "Article", new { area = "Admin" });
            }
            TempData["error"] = "Bir hata oluştu.";
            return RedirectToAction("Index", "Article", new { area = "Admin" });
        }

        [HttpPost]
        public IActionResult UploadImage(IList<FormFile> files)
        {
            var filePath = "";
            foreach (var image in Request.Form.Files)
            {
                string serverMapPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets/img/article_images/", image.FileName);
                using (var stream = new FileStream(serverMapPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                filePath = "https://localhost:44374/" + "assets/img/article_images/" + image.FileName;
            }

            return Json(new { url = filePath });
        }
    }
}
