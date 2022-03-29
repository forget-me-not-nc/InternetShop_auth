using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(item => item.Id);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(p => p.Address)
                 .IsRequired()
                 .HasColumnType("text");

            builder.Property(p => p.IsDeleted)
                .IsRequired();
        }
    }
}
