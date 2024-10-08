﻿using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models.UserModels
{
    [Table("Roles")]
    public class Role : BaseModel<int>
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<RolePermission> RolePermissions { get; set; } = [];
        public ICollection<User> Users { get; set; } = [];
    }
}
