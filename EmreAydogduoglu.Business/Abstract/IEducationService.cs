using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.Business.Abstract
{
    public interface IEducationService
    {
        IList<Education> GetEducations();
        Education GetById(int id);
        void Add(Education education);
        void Update(Education education);
        void Delete(Education education);
    }
}
