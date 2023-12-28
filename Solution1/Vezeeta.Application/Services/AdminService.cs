using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Interfaces.ServiceInterfaces;
using Vezeeta.Core.Models;

namespace Vezeeta.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<bool> AddAdmin(Admin admin)
        {
            return await _adminRepository.AddAdmin(admin);
        }

        public async Task<List<AdminDto>> GetPaginatedAdminsAsync(int page, int pageSize)
        {
            return await _adminRepository.GetPaginatedAdminsAsync(page, pageSize);
        }
    }
}
