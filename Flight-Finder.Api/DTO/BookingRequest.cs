namespace Flight_Finder.Api.DTO
{
    public class BookingRequest
    {
        public int NumberOfSeats { get; set; }
        public string FlightId { get; set; }
        public string UserId { get; set; }
    }
}
