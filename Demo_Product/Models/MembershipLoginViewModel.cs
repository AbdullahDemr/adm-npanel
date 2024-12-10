using System.ComponentModel.DataAnnotations;

namespace Demo_Product.Models
{
    public class MembershipLoginViewModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen parolayı giriniz")]

        public string Password { get; set; }
    }
}
