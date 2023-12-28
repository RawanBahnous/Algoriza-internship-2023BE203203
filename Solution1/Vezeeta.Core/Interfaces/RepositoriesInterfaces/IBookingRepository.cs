using Vezeeta.Core.DTOs;
using Vezeeta.Core.Models;

namespace Vezeeta.Core.Interfaces.RepositoriesInterfaces
{
    public interface IBookingRepository
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
