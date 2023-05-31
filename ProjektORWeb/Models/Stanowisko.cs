using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektORWeb.Models
{
    [Table("Stanowisko")]
    public class Stanowisko
    {

        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Nazwa { get; set; }
    }
}
