using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.Business.Abstract
{
    public interface ISkillService
    {
        IList<Skill> GetSkills();
        Skill GetById(int id);
        void Add(Skill skill);
        void Update(Skill skill);
        void Delete(Skill skill);
    }
}
