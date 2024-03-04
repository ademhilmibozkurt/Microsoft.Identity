
using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class UserCreateModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Geçerli email formatı giriniz.")]
        [Required(ErrorMessage = "Email boş geçilemez!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!!")]
        public string ConfirmedPassword { get; set; }

        [Required(ErrorMessage = "Cinsiyet boş geçilemez!")]
        public string Gender { get; set; }
    }
}
