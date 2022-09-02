using EmreAydogduoglu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmreAydogduoglu.Data.Concrete.EntityFramework.Mappings
{
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(150);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(250);
            builder.Property(p => p.Link).IsRequired();
            builder.Property(p => p.Link).HasMaxLength(150);
        }
    }
}
