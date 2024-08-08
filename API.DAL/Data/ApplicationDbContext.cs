using API.Domain.Enums;
using API.Domain.Models;
using API.Domain.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace API.DAL.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options/*, IOptions<AuthorizationOptions> authOptions*/) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasData(
                new City() { Id = 1, Name = "Набережные Челны" }
            );

            modelBuilder.Entity<Brand>().HasData(
                new Brand() { Id = 1, Name = "Android" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1 }
            );

            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory() { Id = 1, CategoryId = 1 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = Guid.NewGuid(), Name = "123", Price = 12455.01M, Description = "WTF", CityId = 1, BrandId = 1, CategoryId = 1, SubCategoryId = 1 }
            );

            modelBuilder.Entity<Cart>().HasData(
                new Cart() { Id = Guid.NewGuid() }
            );

            modelBuilder.Entity<Permission>().HasData(
                Enum.GetValues<Permissions>().Select(x =>
                new Permission { Id = (int)x, Name = x.ToString() }));

            modelBuilder.Entity<Role>().HasData(
                Enum.GetValues<Roles>().Select(x =>
                new Role { Id = (int)x, Name = x.ToString() }));

            //TODO: Many to many RolePermissions - authOptions
        }
    }
}
