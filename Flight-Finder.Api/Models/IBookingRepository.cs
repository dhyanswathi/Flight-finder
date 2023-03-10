using Flight_Finder.Api.DTO;

namespace Flight_Finder.Api.Models
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAllBookings();
        Booking? GetBooking(string bookingId);
        IEnumerable<Booking?> GetBookingsForUser(string userId);
        Booking CreateBooking(BookingRequest request);
        void DeleteBooking(string bookingId);
        void SaveBooking();
    }
}
