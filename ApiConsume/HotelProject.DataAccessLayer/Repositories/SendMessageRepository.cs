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
    public class SendMessageRepository : GenericRepository<SendMessage>, ISendMessageDal
    {
        public SendMessageRepository(Context context) : base(context)
        {

        }

        public int GetSendMessageCount()
        {
            var c = new Context();
            return c.SendMessages.Count();
        }
    }
}
