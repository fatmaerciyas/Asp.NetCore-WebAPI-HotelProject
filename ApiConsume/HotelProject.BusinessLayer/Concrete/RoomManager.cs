using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class RoomManager : IRoomService
    {

        private readonly IRoomDal roomDal;
    
        public RoomManager(IRoomDal roomDal)
        {
            this.roomDal = roomDal;
        }

        public Task<Room> GetAsync(Expression<Func<Room, bool>> filter)
        {
            return roomDal.GetAsync(filter);
        }

        public Task<Room> GetByIDAsync(int id)
        {
            return roomDal.GetByIDAsync(id);
        }


        public Task<IEnumerable<Room>> GetListAllAsync()
        {
            return roomDal.GetListAllAsync(); 
        }


        public void TAdd(Room t)
        {
            roomDal.Insert(t);
        }

        public void TDelete(Room t)
        {
            roomDal.Delete(t);
        }

        public void TUpdate(Room t)
        {
            roomDal.Update(t);
        }
    }
}
