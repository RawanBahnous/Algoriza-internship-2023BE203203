using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Interfaces.ServiceInterfaces;
using Vezeeta.Core.Models;

namespace Vezeeta.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public bool AddDoctor(AddDoctorDto Doctor)
        {
            return _doctorRepository.AddDoctor(Doctor);
        }

        public void ConfirmCheckup()
        {
            throw new NotImplementedException();
        }

        public int CountDoctors()
        {
            return _doctorRepository.CountDoctors();

        }

        public bool DeleteDoctor(string id)
        {
            return _doctorRepository.DeleteDoctor(id);

        }

        public Doctor GetDoctor(string id)
        {
            return _doctorRepository.GetDoctor(id);

        }

        public List<Doctor> GetDoctors(int page, int pageSize, string search)
        {
            return _doctorRepository.GetDoctors(page,pageSize,search);

        }

        public Doctor SearchDoctor(string name)
        {
            return _doctorRepository.SearchDoctor(name);

        }

        public List<Doctor> TopDoctors()
        {
            return _doctorRepository.TopDoctors();

        }

        public bool UpdateDoctor(string id, DoctorDto Doctor)
        {
            return _doctorRepository.UpdateDoctor(id, Doctor);
        }

    }
}
