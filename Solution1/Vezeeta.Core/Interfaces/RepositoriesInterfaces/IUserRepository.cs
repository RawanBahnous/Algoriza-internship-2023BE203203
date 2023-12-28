using System.IdentityModel.Tokens.Jwt;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Models;
using Vezeeta.Presentation.DTOs;
using Vezeeta.Presentation.Models;

namespace Vezeeta.Core.Interfaces.RepositoriesInterfaces
{
    public interface IUserRepository
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
        Task<JwtSecurityToken> GenerateJwtToken(ApplicationUser user);
    }
}
