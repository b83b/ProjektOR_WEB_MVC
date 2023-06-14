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
        [MaxLength(4)]
        public int? Rok { get; set; }

        
        //public string? Hiperlacze { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public DateTime DataWplywu { get; set; }


        [MaxLength(100)]
        public string? Uwagi { get; set; }


        

        [Required(ErrorMessage = "Pole jest wymagane")]
        public int? Typ { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public int OsobaProwadzaca { get; set; }

        public int? OsobaZatwierdzajaca { get; set; }


        [Required(ErrorMessage = "Pole jest wymagane")]
        public int? Status { get; set; }

        [NotMapped]
        public string Zarzadcy { get; set; }


        //-----RELACJE z TYPEM (1 do WIELU)-----------------------
        //FK

        //[ForeignKey(nameof(Typ))]
        //public virtual Type TypNav { get; set; }


        [ForeignKey(nameof(Status))]
        public virtual Status? StatusNav { get; set; }

        ////[Required(ErrorMessage = "Pole jest wymagane")]
        //[ForeignKey(nameof(OsobaProwadzaca))]
        //public virtual OsobaPraca? OsobaPracaProwadzaca { get; set; }


        //[ForeignKey(nameof(OsobaZatwierdzajaca))]
        //public virtual OsobaPraca? OsobaPracaZatwierdzajaca { get; set; }



        //-----RELACJE z ZARZADCA(WIELE do WIELU)
        public virtual ICollection<ZarzadcaDrogi> ZarzadcaDrogisId { get; set; } //- relacja wiele do wielu ---zarzadca

        public override bool Equals(object? obj)
        {
            return obj is ProjektOR oR &&
                   Id == oR.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
