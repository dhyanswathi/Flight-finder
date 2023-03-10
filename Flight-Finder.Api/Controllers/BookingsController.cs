using Flight_Finder.Api.DTO;
using Flight_Finder.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Finder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepo;
        public BookingsController(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        [HttpPost]
        public IActionResult AddBooking(BookingRequest request)
        {
            try
            {
                var result = _bookingRepo.CreateBooking(request);
                var booking = new DTO.Booking()
                {
                    BookingId = result.BookingId,
                    BookingDate = result.BookingDate,
                    FlightId = result.FlightId,
                    Adults = result.Adults,
                    Child = result.Child,
                    Price = result.Price,
                    UserId = result.UserId
                };
                return Created("", booking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(string id)
        {
            try
            {
                var result = _bookingRepo.GetBooking(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }
        }

        [HttpDelete]
        public IActionResult CancelBooking(string  id)
        {
            _bookingRepo.DeleteBooking(id);
            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUserBookings(string userId)
        {
            try
            {
                var result = _bookingRepo.GetBookingsForUser(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }
            
        }
    }
}
