using Microsoft.EntityFrameworkCore;
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
    public class EFProductDal : GenericRepository<Product>, IProductDal
    {
        public EFProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
           var context = new SignalRContext();
           var values=context.Products.Include(x => x.Category).ToList();
           return values;
        }

		public int ProductCount()
		{
            var context = new SignalRContext();
            var values = context.Products.Count();
            return values;
		}

		public int ProductCountByCategoryNameDrink()
		{
			var context = new SignalRContext();

            return context.Products.Where(x => x.CategoryId == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryId).FirstOrDefault())).Count();
		}

		public int ProductCountByCategoryNameHamburger()
		{
			var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryId == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryId).FirstOrDefault())).Count();
			
		}
	}
}
