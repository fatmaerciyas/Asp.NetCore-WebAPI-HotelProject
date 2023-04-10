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
    public class TestimonialManager : ITestimonialService
    {

        private readonly ITestimonialDal TestimonialDal;

        public TestimonialManager(ITestimonialDal TestimonialDal)
        {
            this.TestimonialDal = TestimonialDal;
        }

        public Task<Testimonial> GetAsync(Expression<Func<Testimonial, bool>> filter)
        {
            return TestimonialDal.GetAsync(filter);
        }

        public Task<Testimonial> GetByIDAsync(int id)
        {
            return TestimonialDal.GetByIDAsync(id);
        }


        public Task<IEnumerable<Testimonial>> GetListAllAsync()
        {
            return TestimonialDal.GetListAllAsync();
        }


        public void TAdd(Testimonial t)
        {
            TestimonialDal.Insert(t);
        }

        public void TDelete(Testimonial t)
        {
            TestimonialDal.Delete(t);
        }

        public void TUpdate(Testimonial t)
        {
            TestimonialDal.Update(t);
        }
    }
}
