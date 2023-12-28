using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Models;
using Vezeeta.Infrastructure.Data;

namespace Vezeeta.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly VezeetaDbContext _context;

        public PatientRepository(VezeetaDbContext context)
        {
            _context = context;
        }
        public async Task<int> CountPatients()
        {
            var patientCount = await _context.Patients.CountAsync();
            return patientCount;
        }


        public async Task<PatientDto> GetPatient(string id)
        {
            try
            {
                var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);

                if (patient == null)
                {
                    return null; 
                }

                var patientDto = new PatientDto
                {
                    Image = patient.Image,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Gender = patient.Gender,
                    Phone = patient.Phone,
                    BirthDate = patient.BirthDate,
                    Email = patient.Email,
                    FullName = patient.FullName,
                };

                return patientDto;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<ICollection<Patient>> GetPatients(int page, int pageSize, string search)
        {
            var allPatients = _context.Patients.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                allPatients = allPatients
                      .Where(patient =>
                        patient.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase)
                        || patient.LastName.Contains(search, StringComparison.OrdinalIgnoreCase));
            }


            var paginatedPatients = allPatients
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToList();

            return paginatedPatients;
        }
    }
}
