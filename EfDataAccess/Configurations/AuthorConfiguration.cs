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
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasIndex(a => a.FirstName);
            builder.HasIndex(a => a.LastName);

            builder.Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.BirthDate)
                .IsRequired();

            builder.HasMany(x => x.AuthorBook).WithOne(x => x.Author).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
