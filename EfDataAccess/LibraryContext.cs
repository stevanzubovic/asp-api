using Domain;
using EfDataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDataAccess
{
    public class LibraryContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<Book>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Author>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Genre>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Review>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(e => !e.IsDeleted);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.Now;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-PUDD02G\SQLEXPRESS;Initial Catalog=NeatReads;Integrated Security=True");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookGenre> BookGenres{ get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
    }
}
