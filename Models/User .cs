
using Microsoft.AspNetCore.Identity;

namespace SuperHeroApp.Models
{
    public class User : IdentityUser
    {
        public string Nombre { get; set; }       
        public DateTime FechaRegistro { get; set; }
    }
}
