using ProjektORWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjektORWeb.ViewModels
{
    public class CreatePracownik
    {
        
        [Required(ErrorMessage = "Pole jest wymagane")]
        [MaxLength(20)]
        public string Imie { get; set; } = null!;

        [Required(ErrorMessage = "Pole jest wymagane")]
        [MaxLength(20)]
        public string Nazwisko { get; set; } = null!;

        [Required(ErrorMessage = "Pole jest wymagane")]
        public DateTime DataZatrudnienia { get; set; }

        public DateTime? DataOdejsciazPracy { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [MaxLength(3)]
        public string Symbol { get; set; } = null!;

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Email { get; set; } = null!;


        public int WydzialId { get; set; }

        public int StanowiskoId { get; set; }


        
        public List<Stanowisko> Stanowiskos { get; set; }


        
        public List<Wydzial> Wydzials { get; set; }
    }
}
