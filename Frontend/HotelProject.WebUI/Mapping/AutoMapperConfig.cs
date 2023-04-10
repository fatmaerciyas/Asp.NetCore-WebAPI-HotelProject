using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.RegisterDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.SubscribeDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<CreateNewUserDto, AppUser>().ReverseMap(); //Validasyon da yapar
            CreateMap<LoginUserDto, AppUser>().ReverseMap(); //Validasyon da yapar
            CreateMap<ResultAboutDto, About>().ReverseMap(); //Validasyon da yapar
            CreateMap<UpdateAboutDto, About>().ReverseMap(); //Validasyon da yapar
            CreateMap<ResultStaffDto, Staff>().ReverseMap(); //Validasyon da yapar
            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap(); //Validasyon da yapar
            CreateMap<CreateBookingDto, Booking>().ReverseMap(); //Validasyon da yapar
            CreateMap<ApprovedReservationDto, Booking>().ReverseMap(); //Validasyon da yapar
            CreateMap<CreateGuestDto, Guest>().ReverseMap(); //Validasyon da yapar
            CreateMap<UpdateGuestDto, Guest>().ReverseMap(); //Validasyon da yapar
        }
    }
}
