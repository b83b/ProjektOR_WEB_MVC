using ProjektORWeb.Models;

namespace ProjektORWeb.ViewModels
{
    public class CreatePracownik
    {

        public OsobaPraca Imie { get; set; }

        public OsobaPraca Nazwisko { get; set; }

        public OsobaPraca DataZatrudnienia { get; set; }

        public OsobaPraca DataOdejscia { get; set; }

        public OsobaPraca Symbol { get; set; }
        public List<Stanowisko> Stanowiskos { get; set; }

        public List<Wydzial> Wydzials { get; set; }
    }
}
