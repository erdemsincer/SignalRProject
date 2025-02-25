using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class MoneyCaseManager : IMoneyCaseService
	{
		private IMoneyCaseDal _MoneyCaseDal;

		public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
		{
			_MoneyCaseDal = moneyCaseDal;
		}

		public void TAdd(MoneyCase entity)
		{
			_MoneyCaseDal.Add(entity);
		}

		public void TDelete(MoneyCase entity)
		{
			_MoneyCaseDal.Delete(entity);
		}

		public MoneyCase TGetById(int id)
		{
			return _MoneyCaseDal.GetById(id);
		}

		public List<MoneyCase> TGetListAll()
		{
			return _MoneyCaseDal.GetListAll();
		}

		public decimal TTotalMoneyCaseAmount()
		{
			return _MoneyCaseDal.TotalMoneyCaseAmount();	
		}

		public void TUpdate(MoneyCase entity)
		{
			_MoneyCaseDal.Update(entity);
		}
	}
}
