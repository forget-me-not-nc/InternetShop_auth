using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            string s = Path.Combine(Directory.GetCurrentDirectory(), "../InternetShop_auth");

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../InternetShop_auth"))
                .AddJsonFile("appsettings.json")
                .Build();
            
            return new (new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(config.GetConnectionString("DefaultConnection"))
                .Options);
        }
    }
}
