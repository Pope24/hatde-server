using server_hatde.Entities;
using server_hatde.Requests;
using server_hatde.Responses;

namespace server_hatde.Services
{
    public interface IAuthService
    {
        Task<LoginReponse?> LoginAsync(LoginRequest request);
        Task<bool> RegisterAsync(RegisterRequest request);
        Task<bool> ExistEmail(string email);
        Task<bool> ExistPhone(string phone);
        Task<bool> UpdateUserAsync(User user);
    }
}
