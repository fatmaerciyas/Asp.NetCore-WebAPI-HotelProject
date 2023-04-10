using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Subscribe
    {
        [Key]
        public int SubscribeId { get; set; }
        public string Mail { get; set; }
       
    }

}
