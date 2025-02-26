﻿using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub: Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
		private readonly IOrderService _orderService;

		public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
		}



		public async Task SendStatistic() 
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);

			var value2 = _productService.TProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", value2);

			var value3 = _categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

			var value4 = _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);
			
			var value5=_productService.TProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburgerCount", value5);

			var value6 = _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrinkCount", value6);

			var value7 = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ReceiveProductPriceAvg", value7.ToString("0.00")+"TL");

			var value8 = _productService.TProductNameByMaxPrice();
			await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", value8);

			var value9 = _productService.TProductNameByMinPrice();
			await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value9);

			var value10 =  _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", value10);

		}
		
	}
}
