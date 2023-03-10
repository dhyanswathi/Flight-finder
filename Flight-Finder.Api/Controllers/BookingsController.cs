using Flight_Finder.Api.DTO;
using Flight_Finder.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Finder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly BookingRepository _bookingRepo;
        public BookingsController(BookingRepository bookingRepo) 
        {
            _bookingRepo = bookingRepo;
        }

        [HttpPost]
        public IActionResult AddBooking(BookingRequest request)
        {
            var result = _bookingRepo.CreateBooking(request);
            return Created("", result);
        }

    }
}
