using Microsoft.EntityFrameworkCore;
using MusicHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace MusicHub.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<MusicSingle> MusicSingles { get; set; }
        public DbSet<Song> Songs { get; set; }

        
        




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Music", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Apparel", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Digital", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Ticket", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Subscription", DisplayOrder = 5 }
                );

            modelBuilder.Entity<Product>().HasData(
    new Product { Id = 1, CategoryId = 2, Type = "Physical", Name = "Coming Home Shirt", Description = "Shirt based off of the Home single by Daniel Fears.", ListPrice = 30, Price = 30, Price50 = 25, Price100 = 22, }
    );

            modelBuilder.Entity<Song>().HasData(
                new Song { Id = 2,CategoryId = 1, Type = "Digital", Name = "Home (Live from the Draylen Mason Music Studio)", Description = "Home (Live from the Draylen Mason Music Studio)", ListPrice = 2, Price = 2, Price50 = 2, Price100 = 2,
                Artist = "Daniel Fears", ReleaseDate = new DateTime(2024, 05, 10), Collaborators = new List<string> { "Nathaniel Earl"}, 
                },
                new Song
                {
                    Id = 3,
                    CategoryId = 1,
                    Type = "Digital",
                    Name = "Enough",
                    Description = "Your Light Is Enough",
                    ListPrice = 2,
                    Price = 2,
                    Price50 = 2,
                    Price100 = 2,
                    Artist = "Daniel Fears",
                    ReleaseDate = new DateTime(2024, 12, 01),
                }
                );

        }
    }
}
