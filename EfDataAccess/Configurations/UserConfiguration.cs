using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasIndex(x => x.Email);
            builder.HasIndex(x => x.UserName);

            builder.Property(x => x.FirstName)
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .HasMaxLength(50);

            builder.Property(x => x.UserName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired();

            builder.HasMany(x => x.Reviews).WithOne(r => r.User).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
