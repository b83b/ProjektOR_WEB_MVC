using ProjektORWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjektORWeb.ViewModels
{
    public class CreatePracownik
    {
        
        [Required(ErrorMessage = "Pole jest wymagane")]
        public OsobaPraca Imie { get; set; } = null!;

        [Required(ErrorMessage = "Pole jest wymagane")]
        public OsobaPraca Nazwisko { get; set; } = null!;

        [Required(ErrorMessage = "Pole jest wymagane")]
        public OsobaPraca DataZatrudnienia { get; set; } = null!;

        public OsobaPraca? DataOdejsciazPracy { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public OsobaPraca Symbol { get; set; } = null!;

        [Required(ErrorMessage = "Pole jest wymagane")]
        public OsobaPraca Email { get; set; } = null!;

        [Required(ErrorMessage = "Pole jest wymagane")]
        public List<Stanowisko> Stanowiskos { get; set; } = null!;


        [Required(ErrorMessage = "Pole jest wymagane")]
        public List<Wydzial> Wydzials { get; set; } = null!;
    }
}
