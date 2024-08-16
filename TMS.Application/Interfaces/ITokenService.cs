using TMS.Domain.Entities;

namespace TMS.Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
