using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public interface IDatabaseContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
}