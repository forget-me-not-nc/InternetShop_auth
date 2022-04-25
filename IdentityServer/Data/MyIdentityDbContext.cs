using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Data
{
    public class MyIdentityDbContext : IdentityDbContext
    {
        public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options) : base(options) { }
    }
}
