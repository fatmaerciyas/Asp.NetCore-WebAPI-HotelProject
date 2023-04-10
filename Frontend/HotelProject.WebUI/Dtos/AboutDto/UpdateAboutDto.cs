using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class UpdateAboutDto
    {
        public int AboutId { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Content { get; set; }
        public string RoomCount { get; set; }
        public string StaffCount { get; set; }
        public string CustomerCount { get; set; }
    }
}
