using Flight_Finder.Api.DTO;

namespace Flight_Finder.Api.Models
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAllBookings();
        Booking GetBooking(string bookingId);
        Booking CreateBooking(BookingRequest request);
        void DeleteBooking(string bookingId);
        void UpdateBooking(string bookingId, BookingRequest request);
        void SaveBooking();
    }
}
