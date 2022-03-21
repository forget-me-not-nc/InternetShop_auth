using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(account => account.Id);

            builder.Property(account => account.IsActive)
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(account => account.Balance)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.HasOne(account => account.User)
                .WithOne(user => user.Account)
                .HasForeignKey<Account>(account => account.UserId); 
        }
    }
}
