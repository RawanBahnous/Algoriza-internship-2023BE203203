using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Models;
using Vezeeta.Core.Services;
using Vezeeta.Presentation.DTOs;
using Vezeeta.Presentation.Helper;
using Vezeeta.Presentation.Models;

namespace Vezeeta.Presentation.Services

{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {

            return await _userRepository.RegisterAsync(model);

        }


        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {

            return await _userRepository.GetTokenAsync(model);

        }

        public async Task<string> AddRoleAsync(AddRoleModel model)
        {

            return await _userRepository.AddRoleAsync(model);

        }


    }
}
