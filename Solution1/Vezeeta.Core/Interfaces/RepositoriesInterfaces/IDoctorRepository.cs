using Vezeeta.Core.DTOs;
using Vezeeta.Core.Models;

namespace Vezeeta.Core.Interfaces.RepositoriesInterfaces
{
    public interface IDoctorRepository
    {
        List<Doctor> GetDoctors(int page, int pageSize, string search);
        Doctor GetDoctor(string id);
        bool AddDoctor(AddDoctorDto AddedDoctorDto);
        bool UpdateDoctor(string id, DoctorDto Doctor);
        bool DeleteDoctor(string id);
        Doctor SearchDoctor(string name);
        List<Doctor> TopDoctors();
        int CountDoctors();
        void ConfirmCheckup();
    }
}
