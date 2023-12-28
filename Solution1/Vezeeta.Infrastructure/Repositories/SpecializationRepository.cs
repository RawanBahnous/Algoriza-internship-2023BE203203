using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Models;
using Vezeeta.Infrastructure.Data;

namespace Vezeeta.Infrastructure.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly VezeetaDbContext _context;

        public SpecializationRepository(VezeetaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Specialization>> GetAll()
        {
            return await _context.Specializations.ToListAsync();
        }

        public async Task<Specialization> AddNewSpecialization(Specialization specialization)
        {
            

            var newSpecialization = new Specialization
            {
                //Id = specialization.Id,
                Name = specialization.Name,
                Description = specialization.Description,
                AdminId= specialization.AdminId,
            };

            _context.Specializations.Add(newSpecialization);
            _context.SaveChanges();

            return newSpecialization;
        }

        public async Task<bool> DeleteSpecilization(int id)
        {
            var specializationToDelete =  _context.Specializations.Find(id);

            if (specializationToDelete != null)
            {
                _context.Specializations.Remove(specializationToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<Specialization>> TopSpecilization()
        {

            var topspe = await _context.Specializations
                .OrderByDescending(s => s.Doctors.Count())
                .Take(5)
                .ToListAsync();
            return topspe;

        }
    }

}
