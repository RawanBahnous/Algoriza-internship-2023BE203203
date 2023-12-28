using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Models;
using Vezeeta.Presentation.DTOs;

namespace Vezeeta.Core.Interfaces.ServiceInterfaces
{
    public interface IAppointmentService
    {
        List<Appointment> GetAllAppointments();
        Task<AppoinmentDto> GetAppoinment(int id);
        Task<AppoinmentDto> GetAppoinmentById(int id);

        Appointment AddNewAppointment(AddAppoinmentDto newAppointment);
        Appointment UpdateAppointment(int id, AppoinmentDto newAppointment);
        void DeleteAppointment(int id);
        List<Appointment> SearchAppointments(Days day);

    }
}
