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
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal SendMessageDal;

        public SendMessageManager(ISendMessageDal SendMessageDal)
        {
            this.SendMessageDal = SendMessageDal;
        }

        public Task<SendMessage> GetAsync(Expression<Func<SendMessage, bool>> filter)
        {
            return SendMessageDal.GetAsync(filter);
        }

        public Task<SendMessage> GetByIDAsync(int id)
        {
            return SendMessageDal.GetByIDAsync(id);
        }


        public async Task<IEnumerable<SendMessage>> GetListAllAsync()
        {
            return await SendMessageDal.GetListAllAsync();
        }

        public int GetSendMessageCount()
        {
            return SendMessageDal.GetSendMessageCount();
        }

        public void TAdd(SendMessage t)
        {
            SendMessageDal.Insert(t);
        }

        public void TDelete(SendMessage t)
        {
            SendMessageDal.Delete(t);
        }

        public void TUpdate(SendMessage t)
        {
            SendMessageDal.Update(t);
        }
    }
}
