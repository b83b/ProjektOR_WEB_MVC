using ProjektORWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjektORWeb.ViewModels
{
    public class CreatePracownik
    {
        
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Imie { get; set; } = null!;

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Nazwisko { get; set; } = null!;

        [Required(ErrorMessage = "Pole jest wymagane")]
        public DateTime DataZatrudnienia { get; set; }

        public DateTime? DataOdejsciazPracy { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Symbol { get; set; } = null!;

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Email { get; set; } = null!;


        public int WydzialId { get; set; }

        public int StanowiskoId { get; set; }


        //[Required(ErrorMessage = "Pole jest wymagane")]
        public List<Stanowisko> Stanowiskos { get; set; }


        //[Required(ErrorMessage = "Pole jest wymagane")]
        public List<Wydzial> Wydzials { get; set; }
    }
}
