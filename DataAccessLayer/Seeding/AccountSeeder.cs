using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Seeding
{
    public class AccountSeeder : ISeeder<Account>
    {
        private readonly List<Account> accounts = new()
        {
            new Account
            {
                Id = "eebce548-84a8-43b6-a258-94ecbd9b41cb",
                IsActive = true,
                Balance = 99999.9M
            }
        };

        public void Seed(EntityTypeBuilder<Account> builder) => builder.HasData(accounts);
    }
}
