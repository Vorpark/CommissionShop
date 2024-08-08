using API.Domain.Models.UserModels;

namespace API.Infrastructure.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
