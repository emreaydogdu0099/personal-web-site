using EmreAydogduoglu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmreAydogduoglu.Data.Concrete.EntityFramework.Mappings
{
    public class EducationMap : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(150);
            builder.Property(e => e.FacultyName).IsRequired();
            builder.Property(e => e.FacultyName).HasMaxLength(150);
            builder.Property(e => e.DepartmanName).IsRequired();
            builder.Property(e => e.DepartmanName).HasMaxLength(150);
            builder.Property(e=>e.StartDate).IsRequired();
            builder.Property(e=>e.FinishDate).IsRequired();
            builder.Property(e => e.StartDate).HasColumnType("date");
            builder.Property(e => e.FinishDate).HasColumnType("date");

        }
    }
}
