using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.UI.Areas.Admin.Models
{
    public class ArticleViewModel
    {
        public Article Article { get; set; }
        public IList<Category> Categories { get; set; }
    }
}
