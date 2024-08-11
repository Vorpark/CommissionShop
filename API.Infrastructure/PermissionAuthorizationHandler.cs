using API.DAL.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace API.Infrastructure
{
    public class PermissionAuthorizationHandler(IServiceScopeFactory serviceScopeFactory) : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var userId = context.User.Claims.FirstOrDefault(x => x.Type == CustomClaims.UserId);

            if (userId is null || !Guid.TryParse(userId.Value, out var id))
            {
                return;
            }

            using var scope = _serviceScopeFactory.CreateScope();

            var permissionsService =  scope.ServiceProvider.GetRequiredService<IUserRepository>();

            var permissions = await permissionsService.GetUserPermissionsByGuidAsync(id);

            if (permissions.Intersect(requirement.Permissions).Any())
            {
                context.Succeed(requirement);
            }
        }
    }
}
