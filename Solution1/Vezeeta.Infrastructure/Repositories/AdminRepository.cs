using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Models;
using Vezeeta.Infrastructure.Data;

namespace Vezeeta.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly VezeetaDbContext _context;

        public AdminRepository(VezeetaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAdmin(Admin admin)
        {
            try
            {
                _context.Admins.Add(admin);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<List<AdminDto>> GetPaginatedAdminsAsync(int page, int pageSize)
        {
            try
            {
                var admins = _context.Admins
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(a => new AdminDto
                    {
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Email = a.Email,
                        UserName = a.UserName,
                        Phone = a.Phone,
                        Gender=a.Gender,
                        Image= a.Image,
                    })
                    .ToList();

                return admins;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetPaginatedAdminsAsync: {ex.Message}");
                throw; 
            }
        }

    }
}
