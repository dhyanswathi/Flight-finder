namespace Flight_Finder.Api.DTO
{
    public class Itinerary
    {
        public string FlightId { get; set; }
        public DateTime DepartureAt { get; set; }
        public DateTime ArrivalAt { get; set; }
        public int AvailableSeats { get; set; }
        public string RouteId { get; set; }
        public string Currency { get; set; }
        public double AdultPrice { get; set; }
        public double ChildPrice { get; set; }
    }
}
