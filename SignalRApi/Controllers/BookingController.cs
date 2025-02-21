using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Date = createBookingDto.Date,
                Email = createBookingDto.Email, 
                Name = createBookingDto.Name,
                Phone = createBookingDto.Phone,
                PersonCount = createBookingDto.PersonCount,
            };
            _bookingService.TAdd(booking);
            return Ok("eklendi");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingId = updateBookingDto.BookingId,
                Date = updateBookingDto.Date,
                Email = updateBookingDto.Email,
                Name = updateBookingDto.Name,
                Phone = updateBookingDto.Phone,
                PersonCount = updateBookingDto.PersonCount,
            };

            _bookingService.TUpdate(booking);
            return Ok("Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }

    }
}
