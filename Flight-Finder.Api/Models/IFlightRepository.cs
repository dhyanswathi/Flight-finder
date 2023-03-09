namespace Flight_Finder.Api.Models
{
    public interface IFlightRepository
    {
        void Save();
        IEnumerable<FlightRoute> GetAllRoutes();
        FlightRoute? GetById(string id);
        IEnumerable<Itinerary> GetAllFlights(string dep, string arr);

        IEnumerable<Itinerary> GetFlightsByTime(DateTime travelDate);
    }
}
