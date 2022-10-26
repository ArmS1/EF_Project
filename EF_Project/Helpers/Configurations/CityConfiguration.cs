using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EF_Project.Entities;

namespace EF_Project.Helpers.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(ci => ci.Country)
                .WithMany(co => co.Cities)
                .HasForeignKey(ci => ci.CountryId);
        }
    }
}
