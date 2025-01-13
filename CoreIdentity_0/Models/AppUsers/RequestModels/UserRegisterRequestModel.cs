using System.ComponentModel.DataAnnotations;

namespace CoreIdentity_0.Models.AppUsers.RequestModels
{
    public class UserRegisterRequestModel
    {
        [Required(ErrorMessage ="{0} alanı zorunludur")]
        [Display(Name ="Kullanıcı ismi")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="{0} alanı zorunludur")]
        [Display(Name ="Sifre")]
        [MinLength(4,ErrorMessage ="{0} , minimum {1} karakter alabilir")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Parolalar uyusmuyor")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }


    }
}
