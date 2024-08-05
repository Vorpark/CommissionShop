using API.Domain.Models;

namespace API.Infrastructure.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
