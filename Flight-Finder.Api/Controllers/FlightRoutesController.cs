using Flight_Finder.Api.DTO;
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

        [HttpGet("itineraries")]
        public IActionResult GetFlights([FromQuery] Filter filter)
        {
            try
            {
                var result = _repo.GetAllFlights(filter).Select(x => new DTO.Itinerary()
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

        [HttpGet("{dep}/{arr}")]
       public IActionResult GetConnectionFlights(string dep, string arr)
        {
            try
            {
                var result = _repo.GetConnectionFlights(dep, arr).Select(x => new DTO.Itinerary[2]
                {
                    new DTO.Itinerary()
                    {
                        FlightId = x[0].FlightId,
                    DepartureAt =  x[0].DepartureAt,
                    ArrivalAt =  x[0].ArrivalAt,
                    AvailableSeats =  x[0].AvailableSeats,
                    RouteId =  x[0].RouteId,
                    Currency =  x[0].Currency,
                    AdultPrice =  x[0].AdultPrice,
                    ChildPrice =  x[0].ChildPrice,
                    },
                    new DTO.Itinerary()
                    {
                        FlightId =  x[1].FlightId,
                    DepartureAt = x[1].DepartureAt,
                    ArrivalAt =  x[1].ArrivalAt,
                    AvailableSeats = x[1].AvailableSeats,
                    RouteId = x[1].RouteId,
                    Currency = x[1].Currency,
                    AdultPrice = x[1].AdultPrice,
                    ChildPrice = x[1].ChildPrice,
                    }
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
