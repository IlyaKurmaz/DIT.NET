using DIT.Domain.Models.AuthModel;
using System.Threading.Tasks;

namespace DIT.API.Services
{
    public interface IJWTAuthService
    {
        Task<JwtTokenResponse> Authenticate(string username, string password);
    }
}