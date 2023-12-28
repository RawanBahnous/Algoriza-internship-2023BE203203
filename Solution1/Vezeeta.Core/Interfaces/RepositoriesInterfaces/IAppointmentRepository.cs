using Vezeeta.Core.DTOs;
using Vezeeta.Core.Models;
using Vezeeta.Presentation.DTOs;

namespace Vezeeta.Core.Interfaces.RepositoriesInterfaces
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAllAppointments();
        Task<AppoinmentDto> GetAppoinment(int id);
        Appointment AddNewAppointment(AddAppoinmentDto newAppointment);
        Appointment UpdateAppointment(int id , AppoinmentDto newAppointment);
        void DeleteAppointment(int id);
        List<Appointment> SearchAppoinments(Days day);

    }
}
