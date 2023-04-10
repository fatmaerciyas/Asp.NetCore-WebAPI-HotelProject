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
    public class ServiceManager : IServiceService
    {

        private readonly IServiceDal ServiceDal;

        public ServiceManager(IServiceDal ServiceDal)
        {
            this.ServiceDal = ServiceDal;
        }

        public Task<Service> GetAsync(Expression<Func<Service, bool>> filter)
        {
            return ServiceDal.GetAsync(filter);
        }

        public Task<Service> GetByIDAsync(int id)
        {
            return ServiceDal.GetByIDAsync(id);
        }


        public Task<IEnumerable<Service>> GetListAllAsync()
        {
            return ServiceDal.GetListAllAsync();
        }


        public void TAdd(Service t)
        {
            ServiceDal.Insert(t);
        }

        public void TDelete(Service t)
        {
            ServiceDal.Delete(t);
        }

        public void TUpdate(Service t)
        {
            ServiceDal.Update(t);
        }
        //{
        //    public ServiceManager(IGenericDal<Service> genericDal) : base(genericDal)
        //    {
        //    }
    }
}
