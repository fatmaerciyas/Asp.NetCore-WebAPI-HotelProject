using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    //BURADA TUM MANAGERLARI TEK NOKTADAN YONETMEYE CALISTIM
    public class GenericManager<T> : IGenericService<T> where T : class
    {

        IGenericDal<T> genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            this.genericDal = genericDal;
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return genericDal.GetAsync(filter);
        }

        public Task<T> GetByIDAsync(int id)
        {
            return genericDal.GetByIDAsync(id);
        }


        public Task<IEnumerable<T>> GetListAllAsync()
        {
            return genericDal.GetListAllAsync();
        }


        public void TAdd(T t)
        {
            genericDal.Insert(t);
        }

        public void TDelete(T t)
        {
            genericDal.Delete(t);
        }

        public void TUpdate(T t)
        {
            genericDal.Update(t);
        }
    }
}
