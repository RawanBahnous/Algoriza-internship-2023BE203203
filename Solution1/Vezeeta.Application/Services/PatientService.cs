using Microsoft.AspNetCore.Mvc.RazorPages;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Interfaces.ServiceInterfaces;
using Vezeeta.Core.Models;

namespace Vezeeta.Application.Services
{
    public class PatientService : IPatientService
    {

        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }


        public async Task<int> CountPatients()
        {
            return await _patientRepository.CountPatients();
        }

        public async Task<PatientDto> GetPatient(string id)
        {
            return await _patientRepository.GetPatient(id);
        }

        public async Task<ICollection<Patient>> GetPatients(int page, int pageSize, string search)
        {
            var res = await _patientRepository.GetPatients(page, pageSize, search);
            return res;
        }
    }
}
