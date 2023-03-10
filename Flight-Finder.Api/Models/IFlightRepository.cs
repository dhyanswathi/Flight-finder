using Flight_Finder.Api.DTO;

namespace Flight_Finder.Api.Models
{
    public interface IFlightRepository
    {
        void Save();
        IEnumerable<FlightRoute> GetAllRoutes();
        FlightRoute? GetById(string id);
        Itinerary? GetFlightById(string id);
        IEnumerable<Itinerary> GetAllFlights(Filter filter);
        IEnumerable<Itinerary[]> GetConnectionFlights(string dep, string arr);
        bool SeatsAvailable(string id, int seats);
        void UpdateSeatAvailability(string id, int seats);
        void UpdateSeatAfterCancellation(string id, int seats);
        double GetPrice(string flightId, int adult, int? child);
    }
}
