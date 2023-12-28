using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Models;

namespace Vezeeta.Core.Interfaces.ServiceInterfaces
{
    public interface IAdminService
    {
        Task<List<AdminDto>> GetPaginatedAdminsAsync(int page, int pageSize);
        Task<bool> AddAdmin(Admin admin);
    }
}
