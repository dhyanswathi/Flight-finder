using System.Xml.Linq;

namespace Flight_Finder.Api.Models
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightFinderDBContext _context;
        public FlightRepository(FlightFinderDBContext context) => _context = context;
        public IEnumerable<FlightRoute> GetAllRoutes()
        {
            return _context.FlightRoutes;
        }

        public FlightRoute? GetById(string id)
        {
            return _context.FlightRoutes.FirstOrDefault(x => x.RouteId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
