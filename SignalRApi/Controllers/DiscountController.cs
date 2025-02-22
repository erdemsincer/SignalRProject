using AutoMapper;
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
        private readonly IMapper _mapper;



        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
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
            var values = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(values);
            return Ok("eklendi");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var values = _mapper.Map<Discount>(updateDiscountDto);

            _discountService.TUpdate(values);
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
