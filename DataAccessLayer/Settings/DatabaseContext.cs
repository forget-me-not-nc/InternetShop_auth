using DataAccessLayer.Configurations;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
