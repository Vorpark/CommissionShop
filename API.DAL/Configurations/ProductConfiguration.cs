using API.Domain.Models;
using API.Domain.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace API.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product() { Id = Guid.NewGuid(), Name = "123", Price = 12455.01M, Description = "WTF", CityId = 1, BrandId = 1, CategoryId = 1, SubCategoryId = 1 }
            );
        }
    }
}
