using API.DAL.Data;
using API.DAL.Repositories.IRepository;
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

        //TODO: Update
    }
}
