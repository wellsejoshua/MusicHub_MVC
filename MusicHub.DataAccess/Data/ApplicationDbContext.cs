using Microsoft.EntityFrameworkCore;
using MusicHub.Models;

namespace MusicHub.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Music", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Apparel", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Digital", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Ticket", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Subscription", DisplayOrder = 5 }
                );

        }
    }
}
