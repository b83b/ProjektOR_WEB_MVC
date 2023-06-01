using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektORWeb.Models
{
    [Table("Wydzial")]
    public class Wydzial
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Symbol { get; set; }

        
    }
}
