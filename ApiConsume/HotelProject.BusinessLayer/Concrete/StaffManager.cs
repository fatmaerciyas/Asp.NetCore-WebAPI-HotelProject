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
    public class StaffManager : IStaffService
    {

        private readonly IStaffDal StaffDal;

        public StaffManager(IStaffDal StaffDal)
        {
            this.StaffDal = StaffDal;
        }

        public Task<Staff> GetAsync(Expression<Func<Staff, bool>> filter)
        {
            return StaffDal.GetAsync(filter);
        }

        public Task<Staff> GetByIDAsync(int id)
        {
            return  StaffDal.GetByIDAsync(id);
        }


        public async Task<IEnumerable<Staff>> GetListAllAsync()
        {
            return await StaffDal.GetListAllAsync();
        }


        public void TAdd(Staff t)
        {
            StaffDal.Insert(t);
        }

        public void TDelete(Staff t)
        {
            StaffDal.Delete(t);
        }

        public void TUpdate(Staff t)
        {
            StaffDal.Update(t);
        }
    }




    //public class StaffManager : GenericManager<Staff>
    //{
    //    public StaffManager(IGenericDal<Staff> genericDal) : base(genericDal)
    //    {
    //    }
    //}
}
