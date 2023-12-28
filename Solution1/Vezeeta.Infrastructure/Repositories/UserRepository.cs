using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Models;
using Vezeeta.Infrastructure.Data;
using Vezeeta.Presentation.DTOs;
using Vezeeta.Presentation.Helper;
using Vezeeta.Presentation.Models;

namespace Vezeeta.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly VezeetaDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWTSettings _jwt;

        public UserRepository(UserManager<ApplicationUser> userManager, IOptions<JWTSettings> jwt, RoleManager<IdentityRole> roleManager, VezeetaDbContext context)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)

                return new AuthModel { Message = "Email is Already Registread" };

            if (await _userManager.FindByNameAsync(model.Username) is not null)
                return new AuthModel { Message = "Username is Already Registread" };

            var user = new ApplicationUser
            {
                
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Image = model.Image,
                Phone = model.Phone,
                UserName = model.Username,
                Gender = model.Gender,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"Errors Found {error.Description} , ";
                }
                return new AuthModel { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "Patient");

            var patient = new Patient
            {
                Id = model.Id,
                Phone = model.Phone,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                Image = model.Image,
                BirthDate = model.Birthdate
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();


            var jwtSecurityToken = await GenerateJwtToken(user);

            return new AuthModel
            {
                ExpiresOn = jwtSecurityToken.ValidTo,
                Email = user.Email,
                IsAuthenticated = true,
                Roles = new List<string> { "Patient" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName

            };
        }



        public async Task<JwtSecurityToken> GenerateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var rolesClaims = new List<Claim>();

            foreach (var role in roles)
            {
                rolesClaims.Add(new Claim("roles", role));
            }

            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id),
            }
            .Union(rolesClaims)
            .Union(userClaims);

            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredntials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(

                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: Claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredntials

                );

            return jwtSecurityToken;

        }


        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {
            var authmodel = new AuthModel();
            var user = await _userManager.FindByEmailAsync(model.Email);


            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authmodel.Message = "Email or Password is incorrect";
                return authmodel;

            }

            var jwtSecurityToken = await GenerateJwtToken(user);

            LogTokenClaims(jwtSecurityToken);

            var rolelist = await _userManager.GetRolesAsync(user);


            authmodel.IsAuthenticated = true;
            authmodel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authmodel.Email = model.Email;
            authmodel.ExpiresOn = jwtSecurityToken.ValidTo;
            authmodel.Roles = rolelist.ToList();

            return authmodel;
        }


        private void LogTokenClaims(JwtSecurityToken token)
        {

            foreach (var claim in token.Claims)
            {
                Console.WriteLine($"Claim Type: {claim.Type}, Value: {claim.Value}");
            }

        }


        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(model.RoleName))
                return "Invalid user id or Role name";


            if (await _userManager.IsInRoleAsync(user, model.RoleName))
                return "user already assigned to this role";

            var result = await _userManager.AddToRoleAsync(user, model.RoleName);

            return result.Succeeded ? string.Empty : "Somthing went wrong";

        }

    }
}
