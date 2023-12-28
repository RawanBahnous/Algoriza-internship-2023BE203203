using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Models;

namespace Vezeeta.Core.Interfaces.ServiceInterfaces
{
    public interface IPatientService
    {
        Task<ICollection<Patient>> GetPatients(int page, int pageSize, string search);
        Task<PatientDto> GetPatient(string id);
        Task<int> CountPatients();
    }
}
