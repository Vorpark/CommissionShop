using API.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace API.Infrastructure
{
    public class PermissionRequirement(Permissions[] permissions) : IAuthorizationRequirement
    {
        public Permissions[] Permissions { get; set; } = permissions; 
    }
}
