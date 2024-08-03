using API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1 }
            );

            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory() { Id = 1, CategoryId = 1 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = Guid.NewGuid(), Name = "123", Price = 12455.01M, Description = "WTF", CategoryId = 1, SubCategoryId = 1 }
            );

        }
    }
}
