using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektORWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ProjektORWeb.ViewModels
{
    public class EditProjekt
    {
        //[Required(ErrorMessage = "Pole jest wymagane")]
        //public ProjektOR NumerProjektu { get; set; } = null!;

        //[Required(ErrorMessage = "Pole jest wymagane")]
        //[MaxLength(4)]
        //public ProjektOR Rok { get; set; }

        //[Required(ErrorMessage = "Pole jest wymagane")]
        //public ProjektOR DataWplywu { get; set; }

        //public ProjektOR? Uwagi { get; set; }
        public ProjektOR? ProjektORs { get; set; }

        public List<SelectListItem> Typ { get; set; }
        public List<OsobaPraca> OsobaProwadzaca { get; set; }


        public List<OsobaPraca>? OsobaZatwierdzajaca { get; set; }

        public List<Status> Status { get; set; }
    }
}
