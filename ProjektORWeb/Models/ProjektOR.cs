using Microsoft.VisualBasic;
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

        
        public string? Hiperlacze { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public DateTime DataWplywu { get; set; }


        [MaxLength(100)]
        public string? Uwagi { get; set; }


        //public int KontynuowaniePoProjekcie { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public int? Typ { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public int? OsobaProwadzaca { get; set; }


        [Required(ErrorMessage = "Pole jest wymagane")]
        public int? Status { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [EmailAddress]
        public string? Email { get; set; }


        //-----RELACJE z TYPEM (1 do WIELU)-----------------------
        //public Type? Typ { get; set; }

        //public int TypId { get; set; }
        
        //public virtual Type Typ { get; set; } //relacja 1/wiele ----Typ

        //public int ? TypId { get; set; }---------------
       

        //-----RELACJE z ZARZADCA (WIELE do WIELU)
        //public virtual ICollection<ZarzadcaProjekt>Zarzadca_drogi_id { get; set; } = new List<Zarzadca> - relacja wiele do wielu ---zarzadca


    }
}
