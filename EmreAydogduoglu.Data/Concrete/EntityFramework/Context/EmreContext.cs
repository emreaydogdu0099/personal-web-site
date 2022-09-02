using EmreAydogduoglu.Data.Concrete.EntityFramework.Mappings;
using EmreAydogduoglu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EmreAydogduoglu.Data.Concrete.EntityFramework.Context
{
    public class EmreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EmreDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new EducationMap());
            modelBuilder.ApplyConfiguration(new SkillMap());
            modelBuilder.ApplyConfiguration(new SocialMap());
            modelBuilder.ApplyConfiguration(new ProjectMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ArticleMap());
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
