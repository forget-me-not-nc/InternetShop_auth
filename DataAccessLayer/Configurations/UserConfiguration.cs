
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(user => user.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(user => user.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(user => user.IsDeleted)
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(user => user.Address)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(user => user.PhoneNumber)
                .HasMaxLength(12)
                .IsRequired();

        }
    }
}
