using ProjektORWeb.Models;

namespace ProjektORWeb.ViewModels
{
    public class InneTabele
    {
        
        public List<Models.Type> Typs { get; set; }

        public List<Status> Statuses { get; set; }

        public List<Stanowisko> Stanowiskos { get; set; }

        public List<Wydzial> Wydzials { get; set; }

        public List<ZarzadcaDrogi> ZarzadcaDrogis { get; set; }
    }
}
