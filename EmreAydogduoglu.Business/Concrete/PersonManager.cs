using EmreAydogduoglu.Business.Abstract;
using EmreAydogduoglu.Data.Abstract;
using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private IPersonDal _personDal;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public Person GetPerson(int id)
        {
            return _personDal.Get(p => p.Id == id);
        }

        public void Update(Person person)
        {
            _personDal.Update(person);
        }
    }
}
