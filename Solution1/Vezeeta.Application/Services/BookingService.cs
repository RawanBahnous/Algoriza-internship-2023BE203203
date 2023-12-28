using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Interfaces.ServiceInterfaces;
using Vezeeta.Core.Models;

namespace Vezeeta.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Task<Booking> AddNewBookingAsync(AddBookingDto booking)
        {
            return _bookingRepository.AddNewBookingAsync(booking);
        }

        public Task<int> BookingCountAsync(string patientId)
        {
            return _bookingRepository.BookingCountAsync(patientId);

        }

        public Task<int> BookingCountByDoctorAsync(string doctorId)
        {
            return _bookingRepository.BookingCountByDoctorAsync(doctorId);

        }

        public Task<Booking> CancelBookingAsync(int bookingid , string docId)
        {
            return _bookingRepository.CancelBookingAsync(bookingid, docId);

        }

        public Task<Booking> ConfirmBookingAsync(int bookingid, string DoctorId)
        {
            return _bookingRepository.ConfirmBookingAsync(bookingid,  DoctorId);

        }

        public Task<List<Booking>> GetAllBookingsByDocIdAsync(string id)
        {
            return _bookingRepository.GetAllBookingsByDocIdAsync(id);

        }

        public Task<List<Booking>> GetAllBookingsByPatientIdAsync(string id)
        {
            return _bookingRepository.GetAllBookingsByPatientIdAsync(id);
        }

        public Task<List<Booking>> SearchBookingsByDocIdAsync(string id)
        {
            return _bookingRepository.SearchBookingsByDocIdAsync(id);

        }

        public Task<List<Booking>> SearchBookingsByPatientIdAsync(string id)
        {
            return _bookingRepository.SearchBookingsByPatientIdAsync(id);

        }
    }
}
