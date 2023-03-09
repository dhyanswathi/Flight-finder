using Flight_Finder.Api.DTO;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace Flight_Finder.Api.Models
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightFinderDBContext _context;
        public FlightRepository(FlightFinderDBContext context) => _context = context;

        public IEnumerable<Itinerary> GetAllFlights(Filter filter)
        {
            var query = _context.Itineraries.AsQueryable();

            if (filter.DepartureLocation != null && filter.ArrivalLocation != null)
            {
                var route = _context.FlightRoutes
                    .Where(x => x.DepartureDestination == filter.DepartureLocation && x.ArrivalDestination == filter.ArrivalLocation)
                    .FirstOrDefault();
                if (route != null)
                {
                    query = query.Where(x => x.RouteId == route.RouteId);
                }
            }

            if (filter.TravelDate != null)
            {
                query = query.Where(x => x.DepartureAt >= filter.TravelDate);
            }

            if (filter.LowPrice != null)
            {
                query = query.Where(x => x.AdultPrice >= filter.LowPrice);
            }

            if (filter.HighPrice  != null)
            {
                query = query.Where(x => x.AdultPrice  <= filter.HighPrice);
            }
            return query.ToList();
        }


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

        public void UpdateSeatAvailability(string id, int seats)
        {
            var flight = GetFlightById(id);

            flight.AvailableSeats -= seats;
            _context.Itineraries.Update(flight);
        }

        public Itinerary? GetFlightById(string flightId)
        {
           return _context.Itineraries.FirstOrDefault(x => x.FlightId == flightId);
        }
    }
}
