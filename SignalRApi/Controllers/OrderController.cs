using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.OrderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;
		private readonly IMapper _mapper;

		public OrderController(IMapper mapper, IOrderService orderService)
		{
			_mapper = mapper;
			_orderService = orderService;
		}



		[HttpGet]
		
		public IActionResult OrderList()
		{
			var values=_orderService.TGetListAll();
			return Ok(values);
		}

		[HttpPost]

		public IActionResult CreateOrder(CreateOrderDto createOrderDto)
		{
			var values = _mapper.Map<Order>(createOrderDto);
			_orderService.TAdd(values);
			return Ok(values);
		}
		[HttpGet("{id}")]
		public IActionResult GetByIdOrder(int id)
		{
			var values=_orderService.TGetById(id);
			return Ok(values);
		}
		[HttpPut]
		public IActionResult UpdateOrder(UpdateOrderDto updateOrderDto)
		{
			var values = _mapper.Map<Order>(updateOrderDto);
			_orderService.TUpdate(values);
			return Ok("Güncellendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteOrder(int id)
		{
			var value = _orderService.TGetById(id);
			_orderService.TDelete(value);
			return Ok("Silindi");
		}
		[HttpGet("TotalOrderCount")]
		public IActionResult TotalOrderCount()
		{
			var value = _orderService.TTotalOrderCount();
			return Ok(value);	
		}
	}
}
