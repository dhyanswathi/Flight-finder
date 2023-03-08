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
                var result = _repo.GetAllRoutes();

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

                return Ok(route);
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }
        }
    }
}
