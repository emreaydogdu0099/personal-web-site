using EmreAydogduoglu.Business.Abstract;
using EmreAydogduoglu.Data.Abstract;
using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.Business.Concrete
{
    public class EducationManager : IEducationService
    {
        private IEducationDal _educationDal;

        public EducationManager(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }

        public IList<Education> GetEducations()
        {
            return _educationDal.GetAll();
        }

        public Education GetById(int id)
        {
            return _educationDal.Get(e => e.Id == id);
        }

        public void Add(Education education)
        {
            _educationDal.Add(education);
        }

        public void Update(Education education)
        {
            _educationDal.Update(education);
        }

        public void Delete(Education education)
        {
            _educationDal.Delete(education);
        }
    }
}
