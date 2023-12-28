using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Models;

namespace Vezeeta.Core.Interfaces.ServiceInterfaces
{
    public interface IDoctorService
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
