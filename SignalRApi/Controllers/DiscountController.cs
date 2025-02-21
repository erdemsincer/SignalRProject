using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _discountService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            Discount discount = new Discount()
            {
                Amount = createDiscountDto.Amount,
                Description = createDiscountDto.Description,
                Title = createDiscountDto.Title,
                ImageUrl = createDiscountDto.ImageUrl

            };
            _discountService.TAdd(discount);
            return Ok("eklendi");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            Discount discount = new Discount()
            {
                DiscountId = updateDiscountDto.DiscountId,
                Amount = updateDiscountDto.Amount,
                Description = updateDiscountDto.Description,
                Title = updateDiscountDto.Title,
                ImageUrl = updateDiscountDto.ImageUrl
            };

            _discountService.TUpdate(discount);
            return Ok("Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(value);
        }
    }
}
