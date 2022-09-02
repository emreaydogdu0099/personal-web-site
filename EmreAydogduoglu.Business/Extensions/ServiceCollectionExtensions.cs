using EmreAydogduoglu.Business.Abstract;
using EmreAydogduoglu.Business.Concrete;
using EmreAydogduoglu.Data.Abstract;
using EmreAydogduoglu.Data.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace EmreAydogduoglu.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPersonService, PersonManager>();
            serviceCollection.AddScoped<IPersonDal, EfPersonDal>();
            serviceCollection.AddScoped<IEducationService, EducationManager>();
            serviceCollection.AddScoped<IEducationDal, EfEducationDal>();
            serviceCollection.AddScoped<ISkillService, SkillManager>();
            serviceCollection.AddScoped<ISkillDal, EfSkillDal>();
            serviceCollection.AddScoped<ISocialService, SocialManager>();
            serviceCollection.AddScoped<ISocialDal, EfSocialDal>();
            serviceCollection.AddScoped<IProjectService, ProjectManager>();
            serviceCollection.AddScoped<IProjectDal, EfProjectDal>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<ICategoryDal, EfCategoryDal>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            serviceCollection.AddScoped<IArticleDal, EfArticleDal>();
            return serviceCollection;
        }
    }
}
