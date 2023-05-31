using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektORWeb.Models
{
    [Table("Stanowisko")]
    public class Stanowisko
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Nazwa { get; set; }
    }
}
