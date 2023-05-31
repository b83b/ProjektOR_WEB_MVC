using ProjektORWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjektORWeb.ViewModels
{
    public class OsobaStanowiskoWydzial
    {
        [Key]
        public int Identyfikator { get; set; }
        public string Imie { get; set; } = null!;

        public string Nazwisko { get; set; } = null!;

        public DateTime DataZatrudnienia { get; set; }

        public DateTime? DataOdejscia { get; set; }

        public string Symbol { get; set; } = null!;

        public string Wydzial { get; set; } = null!;//z Wydzial

        public string Stanowisko { get; set; } = null!; //ze Stanowisko

        public string Email { get; set; } = null!;

       


    }

}