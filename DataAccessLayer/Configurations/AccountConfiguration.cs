using DataAccessLayer.Entities;
using DataAccessLayer.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(t => t.Id);

            builder.Property(p => p.Balance)
                .IsRequired()
                .HasColumnType("decimal(19,2)");

            builder.Property(p => p.IsActive)
                .IsRequired()
                .HasColumnType("bit");

            builder.HasOne(d => d.User)
                .WithOne(d => d.Account)
                .HasForeignKey<Account>(p => p.UserId);

           // new AccountSeeder().Seed(builder);
        }
    }
}
