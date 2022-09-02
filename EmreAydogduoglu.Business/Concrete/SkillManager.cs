using EmreAydogduoglu.Business.Abstract;
using EmreAydogduoglu.Data.Abstract;
using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.Business.Concrete
{
    public class SkillManager : ISkillService
    {
        private ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public IList<Skill> GetSkills()
        {
            return _skillDal.GetAll();
        }

        public Skill GetById(int id)
        {
            return _skillDal.Get(s => s.Id == id);
        }

        public void Add(Skill skill)
        {
            _skillDal.Add(skill);
        }

        public void Update(Skill skill)
        {
            _skillDal.Update(skill);
        }

        public void Delete(Skill skill)
        {
            _skillDal.Delete(skill);
        }
    }
}
