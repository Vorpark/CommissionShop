using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models.UserModels
{
    [Table("Permissions")]
    public class Permission : BaseModel<int>
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<RolePermission> RolePermissions { get; set; } = [];
    }
}
