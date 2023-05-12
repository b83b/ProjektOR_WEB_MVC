namespace ProjektORWeb.Models
{
    public class ProjektOR
    {
        public int Id { get; set; }

        public int NumerProjektu { get; set; }

        public int Rok { get; set; }

        public string Hiperlacze { get; set; }

        public string DataWplywu { get; set; }

        public string DataZatwierdzeniaOd { get; set; }

        public string DataZatwierdzeniaDo { get; set; }

        public string Uwagi { get; set; }

        public int KontynuowaniePoProjekcie { get; set; }

        public int Typ { get; set; }

        public int OsobaProwadzaca { get; set; }

        public int OsobaZatwierdzajaca { get; set; }

        public int Status { get; set; }
    }
}
