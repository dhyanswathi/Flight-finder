using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace Flight_Finder.Api.Models
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightFinderDBContext _context;
        public FlightRepository(FlightFinderDBContext context) => _context = context;

        public IEnumerable<Itinerary> GetAllFlights(string dep, string arr)
        {
            var flightRoutes = _context.FlightRoutes.FirstOrDefault(x => x.DepartureDestination == dep && x.ArrivalDestination == arr);
            if (flightRoutes != null)
            {
                return _context.Itineraries.Where(x => x.RouteId == flightRoutes.RouteId);
            }
            else
            {
                return _context.Itineraries.Take(5);
            }
        }

        public IEnumerable<FlightRoute> GetAllRoutes()
        {
            return _context.FlightRoutes;
        }

        public FlightRoute? GetById(string id)
        {
            return _context.FlightRoutes.FirstOrDefault(x => x.RouteId == id);
        }

        public IEnumerable<Itinerary> GetFlightsByTime(DateTime travelDate)
        {
            return _context.Itineraries.Where(x => x.DepartureAt >= travelDate);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
