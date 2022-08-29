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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasIndex(b => b.Title).IsUnique();
            builder.Property(b => b.Description).IsRequired();

            builder.Property(b => b.Language)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.ReleaseDate)
                .IsRequired();

            builder.HasMany(b => b.BookAuthors).WithOne(y => y.Book).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(b => b.Reviews).WithOne(r => r.Book).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.BookGenre).WithOne(g => g.Book).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
