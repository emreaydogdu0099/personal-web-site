using EmreAydogduoglu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmreAydogduoglu.Data.Concrete.EntityFramework.Mappings
{
    public class SocialMap : IEntityTypeConfiguration<Social>
    {
        public void Configure(EntityTypeBuilder<Social> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.IconName).IsRequired();
            builder.Property(s=>s.Link).IsRequired();
            builder.Property(s => s.Link).HasMaxLength(250);
        }
    }
}
