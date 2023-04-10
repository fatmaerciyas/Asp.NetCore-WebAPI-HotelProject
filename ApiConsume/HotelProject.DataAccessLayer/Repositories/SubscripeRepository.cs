﻿using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Repositories
{
    public class SubscripeRepository : GenericRepository<Subscribe>, ISubscribeDal
    {
        public SubscripeRepository(Context context) : base(context)
        {
        }
    }
}
