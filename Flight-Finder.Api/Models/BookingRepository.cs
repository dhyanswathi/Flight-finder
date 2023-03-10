using Azure.Core;
using Flight_Finder.Api.DTO;

namespace Flight_Finder.Api.Models
{
    public class BookingRepository: IBookingRepository
    {
        private readonly FlightFinderDBContext _context;
        private readonly IFlightRepository _flightRepo;
        public BookingRepository(FlightFinderDBContext context, IFlightRepository flightRepo)
        {
            _context = context;
            _flightRepo = flightRepo;
        }

        public Booking CreateBooking(BookingRequest request)
        {
            int noOfSeats = 0;
            if (request.Child == null)
            {
                noOfSeats = request.Adults;
            }
            else
            {
                noOfSeats = request.Adults + request.Child.Value;
            }
             
            if (_flightRepo.SeatsAvailable(request.FlightId, noOfSeats))
            {
                var booking = new Booking()
                {
                    BookingId = Guid.NewGuid().ToString(),
                    BookingDate = DateTime.Now,
                    Adults = request.Adults,
                    Child = request.Child,
                    FlightId = request.FlightId,
                    UserId = request.UserId,
                    Price = _flightRepo.GetPrice(request.FlightId, request.Adults, request.Child.Value)
                };
                _context.Bookings.Add(booking);
                SaveBooking();

                _flightRepo.UpdateSeatAvailability(request.FlightId, noOfSeats);
                return booking;
            }
            else
            {
                throw new Exception("Not enough seating available. Try another flight");
            }
        }

        public void DeleteBooking(string bookingId)
        {
            var booking = GetBooking(bookingId);

            int noOfSeats = 0;

            if (booking != null)
            {
                if (booking.Child == null)
                {
                    noOfSeats = booking.Adults;
                }
                else
                {
                    noOfSeats = booking.Adults + booking.Child.Value;
                }

                _context.Bookings.Remove(booking);
                _flightRepo.UpdateSeatAfterCancellation(booking.FlightId, noOfSeats);
                SaveBooking();
            }
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Bookings;
        }

        public Booking? GetBooking(string bookingId)
        {
            return _context.Bookings.FirstOrDefault(x => x.BookingId == bookingId);
        }

        public void SaveBooking()
        {
            _context.SaveChanges();
        }
    }
}
