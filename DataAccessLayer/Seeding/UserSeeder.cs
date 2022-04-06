using DataAccessLayer.Entities;
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
        private Dictionary<User, string> users;

        public void Seed(EntityTypeBuilder<User> builder)
        {
            users = new()
            {
                {
                    new User
                    {
                        Id = "83c4eefe-3f50-458d-a227-21f6a7806ab1",
                        FirstName = "Admin",
                        LastName = "Admin",
                        Email = "admin@gmail.com",
                        Address = "none",
                        IsDeleted = false,
                        UserName = "Admin",
                        NormalizedUserName = "ADMIN",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    },
                    "Admin"
                }
            };

            var _passwordHasher = new PasswordHasher<User>();

            var list = users.Select(pair =>
            {
                pair.Key.PasswordHash = _passwordHasher.HashPassword(pair.Key, pair.Value);
                return pair.Key;
            }).ToList();

            builder.HasData(list);
        }
    }
}
