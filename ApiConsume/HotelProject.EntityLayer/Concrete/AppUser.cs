using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int> // gonderdigimiz veri tipi primary key veritipi
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? City { get; set; } = null;
        public string? ImageUrl { get; set; } 
    }
}
