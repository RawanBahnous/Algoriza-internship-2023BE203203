using Vezeeta.Core.DTOs;
using Vezeeta.Core.Models;

namespace Vezeeta.Core.Interfaces.RepositoriesInterfaces
{
    public interface IAdminRepository
    {
        Task<List<AdminDto>> GetPaginatedAdminsAsync(int page, int pageSize);
        Task<bool> AddAdmin(Admin admin);

    }
}
