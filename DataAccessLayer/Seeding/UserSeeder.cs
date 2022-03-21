using DataAccessLayer.Entities;
using DataAccessLayer.Seeding.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Seeding
{
    public class UserSeeder : ISeeder<User>
    {
        private readonly List<(User, string)> _users = new()
        {
            (
                new User
                {
                    Id = "9b1a87d5-1d50-4d89-b948-633871d43381",
                    FirstName = "Nazar",
                    LastName = "Palijchuk",
                    Email = "email",
                    IsDeleted = false,
                    Address = "address"
                },
                "password"
            )

        };
                 

        public void Seed(EntityTypeBuilder<User> builder)
        {
            foreach (var (user, password) in _users)
            {
                user.PasswordHash = new PasswordHasher<User>().HashPassword(user, password);
                builder.HasData(user);
            }
        }
    }
}
