using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Seeding
{
    public class AccountSeeding : ISeeder<Account>
    {
        private static readonly List<Account> accounts = new()
        {
            new Account
            {
                Id = "4a9b7452-b6c7-4b5f-ba66-dda14f6e1cc7",
                Balance = 0.0m,
                IsActive = true
            }
        };

        public void Seed(EntityTypeBuilder<Account> builder) => builder.HasData(accounts);
    }
}
