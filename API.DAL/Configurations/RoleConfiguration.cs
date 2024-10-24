using API.Domain.Enums;
using API.Domain.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace API.DAL.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                Enum.GetValues<Roles>().Select(x =>
                new Role { Id = (int)x, Name = x.ToString() })
            );
        }
    }
}
