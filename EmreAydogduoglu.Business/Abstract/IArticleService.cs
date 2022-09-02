using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.Business.Abstract
{
    public interface IArticleService
    {
        IList<Article> GetArticles();
        IList<Article> GetArticlesByCategoryId(int id);
        Article GetArticleById(int id);
        IList<Article> GetArticlesByDate();
        void Add(Article article);
        void Update(Article article);
        void Delete(Article article);
    }
}
