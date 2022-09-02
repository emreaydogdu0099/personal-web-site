using EmreAydogduoglu.Business.Abstract;
using EmreAydogduoglu.Data.Abstract;
using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        private IProjectDal _projectDal;

        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }

        public IList<Project> GetProjects()
        {
            return _projectDal.GetAll();
        }

        public Project GetById(int id)
        {
            return _projectDal.Get(p => p.Id == id);
        }

        public void Add(Project project)
        {
            _projectDal.Add(project);
        }

        public void Update(Project project)
        {
            _projectDal.Update(project);
        }

        public void Delete(Project project)
        {
            _projectDal.Delete(project);
        }
    }
}
