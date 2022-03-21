using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Seeding
{
    public class UserSeeding : ISeeder<User>
    {
        private static readonly List<User> users = new()
        {
            new User
            {
                Id = "9c3d6db4-5334-4cbe-9497-21b1f23e4f7d",
                FirstName = "user1",
                LastName = "user1",
                Email = "email1",
                Address = "address1",
                IsDeleted = false
            }
        };

        public void Seed(EntityTypeBuilder<User> builder) => builder.HasData(users);
    }
}
