using System.ComponentModel.DataAnnotations;

namespace SuperHeroApp.Models
{
    public class LoginViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        
        [Display(Name = "Recuérdame")]
        public bool RememberMe { get; set; }
    }
}
