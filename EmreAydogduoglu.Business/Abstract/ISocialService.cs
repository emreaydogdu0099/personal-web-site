using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.Business.Abstract
{
    public interface ISocialService
    {
        IList<Social> GetSocials();
        Social GetById(int id);
        void Add(Social social);
        void Update(Social social);
        void Delete(Social social);
    }
}
