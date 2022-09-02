using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.Business.Abstract
{
    public interface ICategoryService
    {
        IList<Category> GetCategories();
        Category GetCategoryById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);

    }
}
