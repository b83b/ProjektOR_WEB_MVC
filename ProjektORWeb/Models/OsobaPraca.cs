using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace ProjektORWeb.Models
{
    [Table("OsobaPraca")]
    public class OsobaPraca
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Imie { get; set; } = null!;

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Nazwisko { get; set; } = null!;

        [Required(ErrorMessage = "Pole jest wymagane")]
        public DateTime DataZatrudnienia { get; set; }

        public DateTime? DataOdejsciazPracy { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Symbol { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public int Wydzial { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public int Stanowisko { get; set; }

        public int? PrzelozonyRekurencja { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Email { get; set; }


        //FK
        [Required(ErrorMessage = "Pole jest wymagane")]
        [ForeignKey(nameof(Wydzial))]
        public virtual Wydzial WydzialNav { get; set; } = null!;

        [Required(ErrorMessage = "Pole jest wymagane")]
        [ForeignKey(nameof(Stanowisko))]
        public virtual Stanowisko StanowiskoNav { get; set; } = null!;

        [ForeignKey(nameof(PrzelozonyRekurencja))]
        public virtual OsobaPraca OsobaPracaRekurencja { get; set; }


    }
}
