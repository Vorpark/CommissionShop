using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models.UserModels
{
    [Table("RolePermissions")]
    public class RolePermission
    {
        public int RoleId { get; set; }
        public Role? Role { get; set; }

        public int PermissionId { get; set; }
        public Permission? Permission { get; set; }
    }
}
