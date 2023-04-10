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
    public class BookingManager : IBookingService
    {

        private readonly IBookingDal bookingDal;

        public BookingManager(IBookingDal BookingDal)
        {
            this.bookingDal = BookingDal;
        }

        public void BookingApproved(Booking model)
        {
            bookingDal.BookingApproved(model);
        }

        public Task<Booking> GetAsync(Expression<Func<Booking, bool>> filter)
        {
            return bookingDal.GetAsync(filter);
        }

        public Task<Booking> GetByIDAsync(int id)
        {
            return bookingDal.GetByIDAsync(id);
        }


        public Task<IEnumerable<Booking>> GetListAllAsync()
        {
            return bookingDal.GetListAllAsync();
        }


        public void TAdd(Booking t)
        {
            bookingDal.Insert(t);
        }

        public void TDelete(Booking t)
        {
            bookingDal.Delete(t);
        }

        public void TUpdate(Booking t)
        {
            bookingDal.Update(t);
        }
    }
}
