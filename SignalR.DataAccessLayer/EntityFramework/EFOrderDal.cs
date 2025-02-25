using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EFOrderDal : GenericRepository<Order>, IOrderDal
	{
		public EFOrderDal(SignalRContext context) : base(context)
		{
		}

		public int ActiveOrderCount()
		{
			using var context = new SignalRContext();
			return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
		}

		public decimal LastOrderPrice()
		{
			using var context=new SignalRContext();
			return context.Orders.OrderByDescending(y => y.OrderId).Take(0).Select(z => z.TotalPrice).FirstOrDefault();
		}

		public decimal TodayTotalPrice()
		{
			using var context = new SignalRContext();
			return context.Orders.Where(x=>x.Date==DateTime.Parse(DateTime.Now.ToShortDateString())).Sum(z=>z.TotalPrice);
		}

		public int TotalOrderCount()
		{
			using var context = new SignalRContext();
			return context.Orders.Count();
		}
	}
}
