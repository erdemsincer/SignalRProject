using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public void TAdd(T entity)
        {
           _genericDal.Add(entity);
           
        }

        public void TDelete(T entity)
        {
          _genericDal.Delete(entity);
        }

        public T TGetById(int id)
        {
           return _genericDal.GetById(id);
        }

        public List<T> TGetListAll()
        {
           return _genericDal.GetListAll();
        }

        public void TUpdate(T entity)
        {
            _genericDal.Update(entity);
        }
}
}
