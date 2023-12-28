using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Interfaces.ServiceInterfaces;
using Vezeeta.Core.Models;
using Vezeeta.Core.Services;
using Vezeeta.Presentation.Models;

namespace Vezeeta.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository userRepository;

        public AdminController(IAdminService adminService, UserManager<ApplicationUser> userManager, IUserRepository userRepository)
        {
            _adminService = adminService;
            _userManager = userManager;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<List<AdminDto>> GetPaginatedAdminsAsync(int page = 1, int pageSize = 3)
        {
            
                var admins = await _adminService.GetPaginatedAdminsAsync(page, pageSize);

                return admins;
            
        }


        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromForm] AdminDto admindto)
        {
            try
            {
                var user = new ApplicationUser
                {
                    FirstName = admindto.FirstName,
                    LastName = admindto.LastName,
                    Email = admindto.Email,
                    Image = admindto.Image,
                    Phone = admindto.Phone,
                    UserName = admindto.UserName,
                    Gender = admindto.Gender,
                };

                var result = await _userManager.CreateAsync(user, admindto.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(new { Message = "Failed to create user", Errors = result.Errors });
                }

                await _userManager.AddToRoleAsync(user, "Admin");

                var admin = new Admin
                {
                    Id = admindto.Id,
                    FirstName = admindto.FirstName,
                    LastName = admindto.LastName,
                    Email = admindto.Email,
                    Image = admindto.Image,
                    Phone = admindto.Phone,
                    UserName = admindto.UserName,
                    Gender = admindto.Gender,
                };

                _adminService.AddAdmin(admin);

                var adminResponseDto = new AdminDto
                {
                    Id = admin.Id,
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    Email = admin.Email,
                    Gender = admin.Gender,
                    Image= admin.Image,
                    Phone = admin.Phone,
                    UserName=admin.UserName
                };

                var jwtSecurityToken = await userRepository.GenerateJwtToken(user);

                var authModel = new AuthModel
                {
                    ExpiresOn = jwtSecurityToken.ValidTo,
                    Email = user.Email,
                    IsAuthenticated = true,
                    Roles = new List<string> { "Admin" },
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Username = user.UserName
                };

                return Ok(adminResponseDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
