using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations
{
    internal class CustomUserConfiguration : IEntityTypeConfiguration<CustomUser>
    {
        public void Configure(EntityTypeBuilder<CustomUser> builder)
        {
            builder.ToTable("CustomUsers");

            builder.HasKey(t => t.Id);

            builder.Property(p => p.Sex)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(p => p.Address)
                .IsRequired();
        }
    }
}
