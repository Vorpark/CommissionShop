using API.DAL.Data;
using API.DAL.Repositories.IRepository;
using API.Domain.Enums;
using API.Domain.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Repositories
{
    public class UserRepository(ApplicationDbContext db) : BaseRepository<User>(db), IUserRepository
    {
        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = await dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
            
            return user;
        }

        public async Task<HashSet<Permissions>> GetUserPermissionsByGuidAsync(Guid userId) //TODO: Рефактор
        {
            var user = await dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId);
            
            var permissions = await _db.RolePermissions.Where(x => x.RoleId == user!.RoleId).Select(x => x.PermissionId).ToListAsync();

            return permissions.Select(x => (Permissions)x).ToHashSet();
        }

        //TODO: Update
    }
}
