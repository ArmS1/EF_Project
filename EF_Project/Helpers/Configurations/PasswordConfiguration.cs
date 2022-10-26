using EF_Project.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Project.Helpers.Configurations
{
    public class PasswordConfiguration : IEntityTypeConfiguration<Password>
    {
        public void Configure(EntityTypeBuilder<Password> builder)
        {
            builder.ToTable("Password");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.PasswordHash)
                .HasMaxLength(500)
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithOne(u => u.Password)
                .HasForeignKey<Password>(p => p.UserId);
        }
    }
}
