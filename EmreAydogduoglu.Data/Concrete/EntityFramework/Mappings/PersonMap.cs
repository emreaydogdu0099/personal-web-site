using EmreAydogduoglu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmreAydogduoglu.Data.Concrete.EntityFramework.Mappings
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p=>p.FirstName).IsRequired();
            builder.Property(p=>p.FirstName).HasMaxLength(25);
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(30);
            builder.Property(p => p.Address).IsRequired();
            builder.Property(p => p.Address).HasMaxLength(150);
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(100);
            builder.Property(p => p.About).IsRequired();
            builder.Property(p => p.About).HasMaxLength(1000);
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Title).HasMaxLength(200);
        }
    }
}
