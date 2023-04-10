using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage = "Ad alanı gereklidir")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad alanı gereklidir")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı alanı gereklidir")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email alanı gereklidir")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Şifre gereklidir")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre onaylama gereklidir")]
        [Compare("Password",ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
