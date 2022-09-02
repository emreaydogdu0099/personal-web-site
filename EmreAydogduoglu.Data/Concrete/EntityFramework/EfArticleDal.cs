using EmreAydogduoglu.Core.Data.Concrete.EntityFramework;
using EmreAydogduoglu.Data.Abstract;
using EmreAydogduoglu.Data.Concrete.EntityFramework.Context;
using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.Data.Concrete.EntityFramework
{
    public class EfArticleDal : EfEntityRepositoryBase<Article,EmreContext>, IArticleDal
    {
        public IList<Article> GetArticlesByDate()
        {
            using EmreContext context = new EmreContext();
            return context.Articles.OrderByDescending(a => a.Date).ToList();
        }
    }
}
