using System.ComponentModel.DataAnnotations;

namespace ProjektORWeb.Models
{
    public class Login
    {
        [Required]
        public string Login1 { get; set; }

        [Required]
        public string Password1 { get; set; }
    }
}
