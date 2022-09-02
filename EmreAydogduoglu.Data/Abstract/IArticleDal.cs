using EmreAydogduoglu.Core.Data.Abstract;
using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.Data.Abstract
{
    public interface IArticleDal : IEntityRepository<Article>
    {
        IList<Article> GetArticlesByDate();
    }
}
