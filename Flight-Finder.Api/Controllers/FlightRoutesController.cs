using Flight_Finder.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Finder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightRoutesController : ControllerBase
    {
        private readonly IFlightRepository _repo;
        public FlightRoutesController(IFlightRepository repo) => _repo = repo;

        [HttpGet]
        public IActionResult GetRoutes()
        {
            try
            {
                var result = _repo.GetAllRoutes().Select(x => new DTO.FlightRoute()
                {
                    RouteId = x.RouteId,
                    DepartureDestination = x.DepartureDestination,
                    ArrivalDestination = x.ArrivalDestination
                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRoute(string id) 
        {
            try
            {
                var route = _repo.GetById(id);
                var flightRoute = new DTO.FlightRoute()
                {
                    RouteId = route.RouteId,
                    DepartureDestination = route.DepartureDestination,
                    ArrivalDestination = route.ArrivalDestination
                };

                return Ok(flightRoute);
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }
        }

        [HttpGet("itineraries/{dep}/{arr}")]
        public IActionResult GetFlightsFromAToB(string dep, string arr)
        {
            try
            {
                var result = _repo.GetAllFlights(dep, arr).Select(x => new DTO.Itinerary()
                {
                    FlightId = x.FlightId,
                    DepartureAt = x.DepartureAt,
                    ArrivalAt = x.ArrivalAt,
                    AvailableSeats = x.AvailableSeats,
                    RouteId = x.RouteId,
                    Currency = x.Currency,
                    AdultPrice = x.AdultPrice,
                    ChildPrice = x.ChildPrice,
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }
        }

        [HttpGet("itineraries")]
        public IActionResult GetFlightsWithRoute(DateTime time)
        {
            try
            {
                var result = _repo.GetFlightsByTime(time).Select(x => new DTO.Itinerary()
                {
                    FlightId = x.FlightId,
                    DepartureAt = x.DepartureAt,
                    ArrivalAt = x.ArrivalAt,
                    AvailableSeats = x.AvailableSeats,
                    RouteId = x.RouteId,
                    Currency = x.Currency,
                    AdultPrice = x.AdultPrice,
                    ChildPrice = x.ChildPrice,
                }); 
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }
        }
    }
}
