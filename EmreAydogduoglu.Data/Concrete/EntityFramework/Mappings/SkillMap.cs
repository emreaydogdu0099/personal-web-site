using EmreAydogduoglu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmreAydogduoglu.Data.Concrete.EntityFramework.Mappings
{
    public class SkillMap : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Name).HasMaxLength(100);
            builder.Property(s=>s.Point).IsRequired();
            builder.Property(s => s.Point).HasMaxLength(100);
        }
    }
}
