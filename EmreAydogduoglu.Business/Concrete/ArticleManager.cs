using EmreAydogduoglu.Business.Abstract;
using EmreAydogduoglu.Data.Abstract;
using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public IList<Article> GetArticles()
        {
            return _articleDal.GetAll();
        }

        public IList<Article> GetArticlesByCategoryId(int id)
        {
            return _articleDal.GetAll(a => a.CategoryId == id).OrderByDescending(a=>a.Date).ToList();
        }
        public Article GetArticleById(int id)
        {
            return _articleDal.Get(a=>a.Id == id);
        }

        public IList<Article> GetArticlesByDate()
        {
            return _articleDal.GetArticlesByDate();
        }

        public void Add(Article article)
        {
            _articleDal.Add(article);
        }

        public void Update(Article article)
        {
            _articleDal.Update(article);
        }

        public void Delete(Article article)
        {
            _articleDal.Delete(article);
        }
    }
}
