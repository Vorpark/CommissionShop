using API.Domain.Enums;
using API.Domain.Models.UserModels;

namespace API.DAL.Repositories.IRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<HashSet<Permissions>> GetUserPermissionsByGuidAsync(Guid userId);
        Task<bool> ChangeRoleAsync(Guid userId, int roleId);
    }
}
