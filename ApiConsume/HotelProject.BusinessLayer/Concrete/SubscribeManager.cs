using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SubscribeManager : ISubscribeService
    {

        private readonly ISubscribeDal SubscribeDal;

        public SubscribeManager(ISubscribeDal SubscribeDal)
        {
            this.SubscribeDal = SubscribeDal;
        }

        public Task<Subscribe> GetAsync(Expression<Func<Subscribe, bool>> filter)
        {
            return SubscribeDal.GetAsync(filter);
        }

        public Task<Subscribe> GetByIDAsync(int id)
        {
            return SubscribeDal.GetByIDAsync(id);
        }


        public Task<IEnumerable<Subscribe>> GetListAllAsync()
        {
            return SubscribeDal.GetListAllAsync();
        }


        public void TAdd(Subscribe t)
        {
            SubscribeDal.Insert(t);
        }

        public void TDelete(Subscribe t)
        {
            SubscribeDal.Delete(t);
        }

        public void TUpdate(Subscribe t)
        {
            SubscribeDal.Update(t);
        }
    }
}
