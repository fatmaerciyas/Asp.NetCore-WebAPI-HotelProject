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
    public class AboutManager : IAboutService
    {

        private readonly IAboutDal aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            this.aboutDal = aboutDal;
        }

        public Task<About> GetAsync(Expression<Func<About, bool>> filter)
        {
            return aboutDal.GetAsync(filter);
        }

        public Task<About> GetByIDAsync(int id)
        {
            return aboutDal.GetByIDAsync(id);
        }


        public Task<IEnumerable<About>> GetListAllAsync()
        {
            return aboutDal.GetListAllAsync();
        }


        public void TAdd(About t)
        {
            aboutDal.Insert(t);
        }

        public void TDelete(About t)
        {
            aboutDal.Delete(t);
        }

        public void TUpdate(About t)
        {
            aboutDal.Update(t);
        }
    }
}
