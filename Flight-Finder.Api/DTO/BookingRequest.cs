namespace Flight_Finder.Api.DTO
{
    public class BookingRequest
    {
        public int Adults { get; set; }
        public int? Child { get; set; }
        public string FlightId { get; set; }
        public string UserId { get; set; }
    }
}
