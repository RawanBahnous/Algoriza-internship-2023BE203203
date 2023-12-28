using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Models;

namespace Vezeeta.Core.Interfaces.ServiceInterfaces
{
    public interface IBookingService
    {
        Task<List<Booking>> GetAllBookingsByPatientIdAsync(string id);
        Task<List<Booking>> GetAllBookingsByDocIdAsync(string id);
        Task<List<Booking>> SearchBookingsByDocIdAsync(string id);
        Task<List<Booking>> SearchBookingsByPatientIdAsync(string id);
        Task<Booking> AddNewBookingAsync(AddBookingDto booking);
        Task<Booking> ConfirmBookingAsync(int bookingid, string DoctorId);
        Task<Booking> CancelBookingAsync(int bookingid, string DoctorId);
        Task<int> BookingCountAsync(string patientId);
        Task<int> BookingCountByDoctorAsync(string doctorId);

    }
}
