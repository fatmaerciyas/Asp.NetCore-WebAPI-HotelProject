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
    public class ContactManager : IContactService
    {
        private readonly IContactDal contactDal;

        public ContactManager(IContactDal contactDal)
        {
            this.contactDal = contactDal;
        }


        public Task<Contact> GetAsync(Expression<Func<Contact, bool>> filter)
        {
            return contactDal.GetAsync(filter);
        }

        public Task<Contact> GetByIDAsync(int id)
        {
            return contactDal.GetByIDAsync(id);
        }

        public int GetContactCount()
        {
            return contactDal.GetContactCount();
        }

        public Task<IEnumerable<Contact>> GetListAllAsync()
        {
            return contactDal.GetListAllAsync();
        }


        public void TAdd(Contact t)
        {
            contactDal.Insert(t);
        }

        public void TDelete(Contact t)
        {
            contactDal.Delete(t);
        }

        public void TUpdate(Contact t)
        {
            contactDal.Update(t);
        }
    }
}
