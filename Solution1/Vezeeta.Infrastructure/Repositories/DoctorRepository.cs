using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Models;
using Vezeeta.Infrastructure.Data;

namespace Vezeeta.Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly VezeetaDbContext _context;

        public DoctorRepository(VezeetaDbContext context)
        {
            _context = context;
        }


        public bool AddDoctor(AddDoctorDto doctorDto)
        {
            try
            {
                if (doctorDto != null)
                {
                    var doctor = new Doctor
                    {
                        FirstName = doctorDto.FirstName,
                        LastName = doctorDto.LastName,
                        Email= doctorDto.Email,
                        BirthDate= doctorDto.BirthDate,
                        Image= doctorDto.Image,
                        Gender= doctorDto.Gender,
                        Phone= doctorDto.Phone,
                        UserName= doctorDto.UserName,
                        SpecializeId= doctorDto.SpecializeId,
                        
                    };

                    _context.Doctors.Add(doctor);
                    _context.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding doctor: {ex}");
                return false;
            }
        }


        public void ConfirmCheckup()
        {
            throw new NotImplementedException();
        }

        public int CountDoctors()
        {
            return _context.Doctors.Count();
        }


        public bool DeleteDoctor(string id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public Doctor GetDoctor(string id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
            return doctor;
        }



        public List<Doctor> GetDoctors(int page, int pageSize, string search)
        {
            var allDoctors = _context.Doctors.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                allDoctors = allDoctors
                      .Where(patient =>
                        patient.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase)
                        || patient.LastName.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            var paginatedDoctors = allDoctors
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return paginatedDoctors;
        }

        public Doctor SearchDoctor(string name)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.FirstName == name);

            return doctor;
        }

        public List<Doctor> TopDoctors()
        {
            //var topdocs = _context.Doctors
            //    .OrderByDescending(d=>d.Bookings.Count())
            //    .Take(5)
            //    .ToList();

            //return topdocs;
            throw new NotImplementedException();

        }

        public bool UpdateDoctor(string id, DoctorDto updatedDoctor)
        {
            var currentDoctor = _context.Doctors.FirstOrDefault(d=>d.Id == id);

            if (currentDoctor != null)
            {
                currentDoctor.FirstName = updatedDoctor.FirstName;
                currentDoctor.LastName = updatedDoctor.LastName;
                currentDoctor.Email = updatedDoctor.Email;
                currentDoctor.Phone = updatedDoctor.Phone;
                currentDoctor.Gender = updatedDoctor.Gender;
                currentDoctor.BirthDate = updatedDoctor.BirthDate;

                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
