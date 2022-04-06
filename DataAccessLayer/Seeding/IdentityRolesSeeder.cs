using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Seeding
{
    public class IdentityRolesSeeder : ISeeder<IdentityRole>
    {
        private readonly List<IdentityRole> roles = new()
        {
            new IdentityRole
            {
                Id = "5d4695c5-ebeb-4c7d-9144-26637787a1ec",
                Name = "Client",
                NormalizedName = "CLIENT"
            },

            new IdentityRole
            {
                Id = "99deb2e8-7cab-4013-a43e-0a8d55308419",
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
        };

        public void Seed(EntityTypeBuilder<IdentityRole> builder) => builder.HasData(roles);
    }
}
