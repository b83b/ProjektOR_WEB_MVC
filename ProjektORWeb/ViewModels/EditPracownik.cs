using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektORWeb.Models;
using Xunit;

namespace ProjektORWeb.ViewModels
{
    public class EditPracownik
    {
        public int Id { get; set; }
        
        public string Imie { get; set; } = null!;

        
        public string Nazwisko { get; set; } = null!;

        
        public DateTime DataZatrudnienia { get; set; }

        public DateTime? DataOdejsciazPracy { get; set; }

        
        public string Symbol { get; set; } = null!;

        
        public string Email { get; set; } = null!;


        public int WydzialId { get; set; }

        public int StanowiskoId { get; set; }


        //public List<OsobaPraca> OsobaPracas { get; set; }

        //[Required(ErrorMessage = "Pole jest wymagane")]
        public List<SelectListItem>? Stanowisko { get; set; }


        //[Required(ErrorMessage = "Pole jest wymagane")]
        public List<SelectListItem>? Wydzials { get; set; }
    }
}
