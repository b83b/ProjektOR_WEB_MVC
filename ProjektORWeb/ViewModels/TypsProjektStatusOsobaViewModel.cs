using ProjektORWeb.Models;

namespace ProjektORWeb.ViewModels
{
    public class TypsProjektStatusOsobaViewModel
    {
        public List<ProjektOR> ProjektORs { get; set; }

        public List<Models.Type> Typs { get; set; }

        public List<Status> Statuses { get; set; }

        public List<OsobaPraca> osobaPracas { get; set; }

        public string? Query { get; set; }
    }
}
