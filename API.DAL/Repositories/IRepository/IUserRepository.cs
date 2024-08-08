using API.Domain.Models.UserModels;

namespace API.DAL.Repositories.IRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        //TODO: Update
    }
}
