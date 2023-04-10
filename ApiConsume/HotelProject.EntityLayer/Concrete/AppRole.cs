using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    //Rol tarafinda customize etmek istediklerimiz
    public class AppRole : IdentityRole<int>
    {
    }
}
