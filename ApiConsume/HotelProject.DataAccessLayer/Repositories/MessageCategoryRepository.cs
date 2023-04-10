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
    public class MessageCategoryRepository : GenericRepository<MessageCategory>, IMessageCategoryDal
    {
        public MessageCategoryRepository(Context context) : base(context)
        {
        }
    }
}
