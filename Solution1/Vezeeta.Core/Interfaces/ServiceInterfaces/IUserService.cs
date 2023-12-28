
using Vezeeta.Core.DTOs;
using Vezeeta.Presentation.DTOs;
using Vezeeta.Presentation.Models;

namespace Vezeeta.Core.Services
{
    public interface IUserService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
