using EmreAydogduoglu.Entities.Concrete;

namespace EmreAydogduoglu.Business.Abstract
{
    public interface IProjectService
    {
        IList<Project> GetProjects();
        Project GetById(int id);
        void Add(Project project);
        void Update(Project project);
        void Delete(Project project);
    }
}
