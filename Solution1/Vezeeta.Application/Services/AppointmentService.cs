using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Interfaces.ServiceInterfaces;
using Vezeeta.Core.Models;
using Vezeeta.Presentation.DTOs;

namespace Vezeeta.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        public Appointment AddNewAppointment(AddAppoinmentDto newAppointment)
        {
            return appointmentRepository.AddNewAppointment(newAppointment);
        }

        public void DeleteAppointment(int id)
        {
            appointmentRepository.DeleteAppointment(id);
        }

        public List<Appointment> GetAllAppointments()
        {
            return appointmentRepository.GetAllAppointments();
        }


        public async Task<AppoinmentDto> GetAppoinmentById(int id)
        {
            return await appointmentRepository.GetAppoinment(id);
        }

        public async Task<AppoinmentDto> GetAppointment(int id)
        {
            return await appointmentRepository.GetAppoinment(id);
        }

        public Appointment SearchAppoinments()
        {
            throw new NotImplementedException();
        }

        public List<Appointment> SearchAppointments(Days day)
        {
            return appointmentRepository.SearchAppoinments(day);
        }

        public Appointment UpdateAppointment(int id, AppoinmentDto updatedAppointment)
        {
            return appointmentRepository.UpdateAppointment(id, updatedAppointment);
        }

        Task<AppoinmentDto> IAppointmentService.GetAppoinment(int id)
        {
            throw new NotImplementedException();
        }
    }
}
