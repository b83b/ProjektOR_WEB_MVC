using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektORWeb.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace ProjektORWeb.ViewModels
{
    public class EditPracownik
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Imie { get; set; } = null!;

        [MaxLength(20)]
        public string Nazwisko { get; set; } = null!;

        
        public DateTime DataZatrudnienia { get; set; }

        public DateTime? DataOdejsciazPracy { get; set; }

        [MaxLength(3)]
        public string Symbol { get; set; } = null!;

        
        public string Email { get; set; } = null!;


        public int WydzialId { get; set; }

        public int StanowiskoId { get; set; }


        
        public List<SelectListItem>? Stanowisko { get; set; }


        
        public List<SelectListItem>? Wydzials { get; set; }
    }
}
