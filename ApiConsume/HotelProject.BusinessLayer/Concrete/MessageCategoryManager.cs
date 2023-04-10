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
    public class MessageCategoryManager : IMessageCategoryService
    {

        private readonly IMessageCategoryDal MessageCategoryDal;

        public MessageCategoryManager(IMessageCategoryDal MessageCategoryDal)
        {
            this.MessageCategoryDal = MessageCategoryDal;
        }

        public Task<MessageCategory> GetAsync(Expression<Func<MessageCategory, bool>> filter)
        {
            return MessageCategoryDal.GetAsync(filter);
        }

        public Task<MessageCategory> GetByIDAsync(int id)
        {
            return MessageCategoryDal.GetByIDAsync(id);
        }


        public Task<IEnumerable<MessageCategory>> GetListAllAsync()
        {
            return MessageCategoryDal.GetListAllAsync();
        }


        public void TAdd(MessageCategory t)
        {
            MessageCategoryDal.Insert(t);
        }

        public void TDelete(MessageCategory t)
        {
            MessageCategoryDal.Delete(t);
        }

        public void TUpdate(MessageCategory t)
        {
            MessageCategoryDal.Update(t);
        }
    }
}
