using API.Domain.Enums;
using API.Domain.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace API.DAL.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasData(
                Enum.GetValues<Permissions>().Select(x =>
                new Permission { Id = (int)x, Name = x.ToString() })
            );
        }
    }
}
