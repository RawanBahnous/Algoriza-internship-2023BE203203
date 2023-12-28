using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Models;
using Vezeeta.Infrastructure.Data;
using Vezeeta.Presentation.DTOs;

namespace Vezeeta.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {

        private readonly VezeetaDbContext _context;

        public AppointmentRepository(VezeetaDbContext context)
        {
            _context = context;
        }

        public Appointment AddNewAppointment(AddAppoinmentDto newAppointment)
        {
            if (newAppointment != null)
            {
                var appointment = new Appointment
                {
                    booked = newAppointment.booked,
                    DoctorId = newAppointment.DoctorId,
                    Days= newAppointment.Days,
                    Price= newAppointment.Price,
                    Time= newAppointment.Time,
                };

                _context.Appointments.Add(appointment);
                _context.SaveChanges();

                return appointment;
            }

            throw new ArgumentNullException(nameof(newAppointment), "New appointment data cannot be null.");
        }


        public Appointment UpdateAppointment(int id, AppoinmentDto updatedAppointment)
        {
            var existingAppointment = _context.Appointments.FirstOrDefault(a=>a.Id == id);

            if (existingAppointment != null)
            {
                if (existingAppointment.booked == false)
                {
                    existingAppointment.Price = updatedAppointment.Price;
                    existingAppointment.booked = updatedAppointment.booked;
                    existingAppointment.Days = updatedAppointment.Days;
                    _context.SaveChanges();


                    var appointment = new Appointment
                    {
                        Id= existingAppointment.Id,
                        booked= existingAppointment.booked,
                        Days= existingAppointment.Days,
                        Price= updatedAppointment.Price,
                    };
                    return appointment;
                }
                else
                {
                    Console.WriteLine("It Can't be updated");
                }
            }
            return null;
        }



        public void DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(x => x.Id == id);
            if (appointment != null)
            {
                if (appointment.booked == false)
                {
                    _context.Appointments.Remove(appointment);
                    _context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("It Can't be removed");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }


        public List<Appointment> GetAllAppointments()
        {
            var appointments = _context.Appointments.ToList();
            return appointments;
        }



        public async Task<AppoinmentDto> GetAppoinment(int id)
        {
            
            try
            {
                var appointment = await _context.Appointments.FirstOrDefaultAsync(p => p.Id == id);

                if (appointment == null)
                {
                    return null;
                }

                var appointmentDto = new AppoinmentDto
                {
                    booked=appointment.booked,
                    Days=appointment.Days,
                    DoctorId=appointment.DoctorId,
                    Price=appointment.Price,
                    Id=appointment.Id
                };

                return appointmentDto;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<Appointment> SearchAppoinments(Days day)
        {
            var appointments = _context.Appointments.Where(a => a.Days == day).ToList();
            return appointments;
        }


        
    }
}
