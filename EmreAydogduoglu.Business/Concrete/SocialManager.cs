using EmreAydogduoglu.Business.Abstract;
using EmreAydogduoglu.Data.Abstract;
using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.Business.Concrete
{
    public class SocialManager : ISocialService
    {
        private ISocialDal _socialDal;

        public SocialManager(ISocialDal socialDal)
        {
            _socialDal = socialDal;
        }

        public IList<Social> GetSocials()
        {
            return _socialDal.GetAll();
        }

        public Social GetById(int id)
        {
            return _socialDal.Get(s => s.Id == id);
        }

        public void Add(Social social)
        {
            _socialDal.Add(social);
        }

        public void Update(Social social)
        {
            _socialDal.Update(social);
        }

        public void Delete(Social social)
        {
            _socialDal.Delete(social);
        }
    }
}
