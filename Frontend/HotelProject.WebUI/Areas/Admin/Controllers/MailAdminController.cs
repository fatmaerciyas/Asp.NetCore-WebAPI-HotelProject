using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailAdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();

        }


        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "fatmaerciyas22@gmail.com");//ilk parametre gonderenin adi.. 2. parametre gonderen maili
            mimeMessage.From.Add(mailboxAddressFrom);//From kismina mailboxAddressFrom'dan gelen degeri ekle
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail); //alici mail
            mimeMessage.To.Add(mailboxAddressTo);//To kisminamailboxAddressTo'yu ekle

            //MESAJIN İCERİGİ 
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            //MESAJ BASLIGI
            mimeMessage.Subject = model.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);// mail adresi, portno, ssl gereksin mi
            client.Authenticate("fatmaerciyas22@gmail.com", "uzmhygyjlhvbdyjf"); //mail ve sifreye ait bir anahtar deger sifrenin kendisi degil
            client.Send(mimeMessage);
            client.Disconnect(true);

            //Gonderilen Mailin veritabanina kaydedilmesi
            return View();

        }
    }
}
