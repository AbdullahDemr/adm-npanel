using System.ComponentModel.DataAnnotations;

namespace Demo_Product.Models
{
    public class MembershipRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen isim değeri giriniz")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Lütfen soyisim giriniz")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Lütfen kullanıcı adı giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Cinsiyet giriniz")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Lütfen e-posta giriniz")]
        public string EMail { get; set; }


        [Required(ErrorMessage = "Lütfen parola giriniz")]
        public string Password { get; set; }

            
        [Required(ErrorMessage = "Lütfen parola giriniz")]
        [Compare("Password", ErrorMessage = "Lütfen parolaların eşleştiğinden emin olun")]
        public string ConfirmPassword { get; set; }


    }
}
