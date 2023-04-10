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
    public class GuestManager : IGuestService
    {

        IGuestDal guestDal;

        public GuestManager(IGuestDal guestDal)
        {
            this.guestDal = guestDal;
        }


        public Task<Guest> GetAsync(Expression<Func<Guest, bool>> filter)
        {
            return guestDal.GetAsync(filter);
        }

        public Task<Guest> GetByIDAsync(int id)
        {
            return guestDal.GetByIDAsync(id);
        }


        public Task<IEnumerable<Guest>> GetListAllAsync()
        {
            return guestDal.GetListAllAsync();
        }


        public void TAdd(Guest t)
        {
            guestDal.Insert(t);
        }

        public void TDelete(Guest t)
        {
            guestDal.Delete(t);
        }

        public void TUpdate(Guest t)
        {
            guestDal.Update(t);
        }
    }
}
