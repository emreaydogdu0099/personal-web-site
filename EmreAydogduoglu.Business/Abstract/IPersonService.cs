using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.Business.Abstract
{
    public interface IPersonService
    {
        Person GetPerson(int id);
        void Update(Person person);
    }
}
