using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektORWeb.Models;
using Xunit;

namespace ProjektORWeb.ViewModels
{
    public class EditPracownik
    {
        //[Required(ErrorMessage = "Pole jest wymagane")]
        public string Imie { get; set; } = null!;

        //[Required(ErrorMessage = "Pole jest wymagane")]
        public string Nazwisko { get; set; } = null!;

        //[Required(ErrorMessage = "Pole jest wymagane")]
        public DateTime DataZatrudnienia { get; set; }

        public DateTime? DataOdejsciazPracy { get; set; }

        //[Required(ErrorMessage = "Pole jest wymagane")]
        public string Symbol { get; set; } = null!;

        //[Required(ErrorMessage = "Pole jest wymagane")]
        public string Email { get; set; } = null!;


        public int WydzialId { get; set; }

        public int StanowiskoId { get; set; }


        //public List<OsobaPraca> OsobaPracas { get; set; }

        //[Required(ErrorMessage = "Pole jest wymagane")]
        public List<SelectListItem> Stanowisko { get; set; }


        //[Required(ErrorMessage = "Pole jest wymagane")]
        public List<SelectListItem> Wydzials { get; set; }
    }
}
