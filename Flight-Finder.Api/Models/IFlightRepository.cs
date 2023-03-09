using Flight_Finder.Api.DTO;

namespace Flight_Finder.Api.Models
{
    public interface IFlightRepository
    {
        void Save();
        IEnumerable<FlightRoute> GetAllRoutes();
        FlightRoute? GetById(string id);
        IEnumerable<Itinerary> GetAllFlights(Filter filter);

    }
}
