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
            var booking = new Booking()
            {
                BookingId = Guid.NewGuid().ToString(),
                BookingDate = DateTime.Now,
                NumberOfSeats = request.NumberOfSeats,
                FlightId = request.FlightId,
                UserId = request.UserId
            };
            _context.Bookings.Add(booking);
            SaveBooking();

            _flightRepo.UpdateSeatAvailability(request.FlightId, request.NumberOfSeats);

            return booking;
        }

        public void DeleteBooking(string bookingId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            throw new NotImplementedException();
        }

        public Booking GetBooking(string bookingId)
        {
            throw new NotImplementedException();
        }

        public void SaveBooking()
        {
            throw new NotImplementedException();
        }

        public void UpdateBooking(string bookingId, BookingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
