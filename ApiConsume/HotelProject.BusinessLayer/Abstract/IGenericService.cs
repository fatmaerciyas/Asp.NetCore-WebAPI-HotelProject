using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TAdd(T t);
        void TUpdate(T t);
        void TDelete(T t);
        Task<IEnumerable<T>> GetListAllAsync();
        Task<T> GetByIDAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        //Task<IEnumerable<T>> GetListAllAsync(Expression<Func<T, bool>> filter);
    }
}
