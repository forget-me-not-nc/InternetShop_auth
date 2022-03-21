using DataAccessLayer.Entities;
using DataAccessLayer.Seeding.Interfaces;
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
        private readonly List<Account> _accounts = new()
        {
            new Account()
            {
                Id = "c327fd72-f21b-459d-947d-021594e62800",
                IsActive = true,
                Balance = 0.0m,
                UserId = "9b1a87d5-1d50-4d89-b948-633871d43381"
            }

        };

        public void Seed(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(_accounts);
        }
    }
}
