using Vezeeta.Core.DTOs;
using Vezeeta.Core.Models;

namespace Vezeeta.Core.Interfaces.RepositoriesInterfaces
{
    public interface IPatientRepository
    {
        Task<ICollection<Patient>> GetPatients(int page, int pageSize, string search);
        Task<PatientDto> GetPatient(string id);
        Task<int> CountPatients();

    }
}
