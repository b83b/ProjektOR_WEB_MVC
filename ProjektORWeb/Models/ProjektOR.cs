using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektORWeb.Models
{
    [Table("ProjektOR")]
    public class ProjektOR
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public int? NumerProjektu { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public int? Rok { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string? Hiperlacze { get; set; }

        //[Required(ErrorMessage = "Pole jest wymagane")]
        //public DateTime DataWplywu { get; set; }


        //public DateTime DataZatwierdzeniaOd { get; set; }


        //public DateTime DataZatwierdzeniaDo { get; set; }


        //[MaxLength(100)]
        //public string? Uwagi { get; set; }


        //public int KontynuowaniePoProjekcie { get; set; }

        //[Required(ErrorMessage = "Pole jest wymagane")]
        //public int? Typ { get; set; }

        //[Required(ErrorMessage = "Pole jest wymagane")]
        //public int? OsobaProwadzaca { get; set; }


        //public int? OsobaZatwierdzajaca { get; set; }

        //[Required(ErrorMessage = "Pole jest wymagane")]
        //public int? Status { get; set; }

        //[Required(ErrorMessage = "Pole jest wymagane")]
        //[EmailAddress]
        //public string? Email { get; set; }
    }
}
