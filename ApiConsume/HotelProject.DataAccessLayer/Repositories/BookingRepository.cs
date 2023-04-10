using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingDal
    {
        public BookingRepository(Context context) : base(context)
        {
        }

        public void BookingApproved(Booking model)
        {
            var context = new Context();
            var values = context.Bookings.Where(x => x.BookId == model.BookId).FirstOrDefault();

            values.Status = "Onaylandı";
            context.SaveChanges();
            
        }
    }
}
