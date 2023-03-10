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
        public bool SeatsAvailable(string id, int seats)
        {
            var flight = GetFlightById(id);
            if (flight == null)
            {
                return false;
            }

            return flight.AvailableSeats >= seats;
        }

        public void UpdateSeatAvailability(string id, int seats)
        {
            var flight = GetFlightById(id);

            flight.AvailableSeats -= seats;
            _context.Itineraries.Update(flight);
            Save();
        }

        public Itinerary? GetFlightById(string flightId)
        {
           return _context.Itineraries.FirstOrDefault(x => x.FlightId == flightId);
        }

        public double GetPrice(string flightId, int adult, int? child)
        {
            var flight = GetFlightById(flightId);
            var adultPrice = flight.AdultPrice * adult;
            var childPrice = flight.ChildPrice * child;

            return adultPrice + childPrice.Value;
        }

        public void UpdateSeatAfterCancellation(string id, int seats)
        {
            var flight = GetFlightById(id);

            flight.AvailableSeats += seats;
            _context.Itineraries.Update(flight);
            Save();
        }

        public IEnumerable<Itinerary[]> GetConnectionFlights(string dep, string arr)
        {
            var routes = new List<string[]>();
            var trips = new List<Itinerary[]>();

            var departure = _context.FlightRoutes.Where(x => x.DepartureDestination == dep).ToList();
            var arrival = _context.FlightRoutes.Where(x => x.ArrivalDestination == arr).ToList();

            foreach (var item in departure)
            {
                var connect = item.ArrivalDestination;
                foreach(var point in arrival)
                {
                    if (point.DepartureDestination == connect)
                    {
                        routes.Add(new string[] { item.RouteId, point.RouteId });
                    }
                }
            }

            foreach (var item in routes)
            {
                var flightA = _context.Itineraries.Where(x => x.RouteId == item[0]).ToList();
                var flightB = _context.Itineraries.Where(x => x.RouteId == item[1]).ToList();

                foreach (var flight in flightA)
                {
                    var arrivalTime = flight.ArrivalAt;

                    foreach (var flight2 in flightB)
                    {
                        if (flight2.DepartureAt > arrivalTime)
                        {
                            trips.Add(new Itinerary[] { flight, flight2 });
                        }
                    }
                }
            }
            return trips;
        }
    }
}
