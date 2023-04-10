using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<Context>();


builder.Services.AddScoped<IRoomDal, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomManager>();


builder.Services.AddScoped<IServiceDal, ServiceRepository>();
builder.Services.AddScoped<IServiceService, ServiceManager>();

builder.Services.AddScoped<IStaffDal, StaffRepository>();
builder.Services.AddScoped<IStaffService, StaffManager>();


builder.Services.AddScoped<ISubscribeDal, SubscripeRepository>();
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();


builder.Services.AddScoped<ITestimonialDal, TestimonialRepository>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();


builder.Services.AddScoped<IAboutDal, AboutRepository>();
builder.Services.AddScoped<IAboutService, AboutManager>();


builder.Services.AddScoped<IBookingDal, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingManager>();


builder.Services.AddScoped<IContactDal, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IGuestDal, GuestRepository>();
builder.Services.AddScoped<IGuestService, GuestManager>();


builder.Services.AddScoped<ISendMessageDal, SendMessageRepository>();
builder.Services.AddScoped<ISendMessageService, SendMessageManager>();


builder.Services.AddScoped<IMessageCategoryDal, MessageCategoryRepository>();
builder.Services.AddScoped<IMessageCategoryService, MessageCategoryManager>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddCors(opt =>
{
    opt.AddPolicy("HotelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("HotelApiCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
