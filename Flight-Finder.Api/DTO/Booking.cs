namespace Flight_Finder.Api.DTO
{
    public class Booking
    {
        public string BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public string FlightId { get; set; }
        public string UserId { get; set; }
        public double Price { get; set; }
        public int Adults { get; set; }
        public int? Child { get; set; }
    }
}
