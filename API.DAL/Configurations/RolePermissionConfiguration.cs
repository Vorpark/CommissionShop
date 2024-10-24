using API.DAL.Data;
using API.Domain.Enums;
using API.Domain.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace API.DAL.Configurations
{
    public class RolePermissionConfiguration(IOptions<AuthorizationOptions> authOptions) : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(t => new { t.RoleId, t.PermissionId });

            builder.HasData(
                authOptions.Value.RolePermissions
                .SelectMany(rp => rp.Permissions
                    .Select(p => new RolePermission
                    {
                        RoleId = (int)Enum.Parse<Roles>(rp.Role),
                        PermissionId = (int)Enum.Parse<Permissions>(p)
                    })).ToArray()
                );
        }
    }
}
