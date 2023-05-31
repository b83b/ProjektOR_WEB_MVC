using ProjektORWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjektORWeb.ViewModels
{
    public class CreateTypsStatusOsoba
    {
        
        [Required(ErrorMessage = "Pole jest wymagane")]
        public ProjektOR NumerProjektu { get; set; } = null!;

        [Required(ErrorMessage = "Pole jest wymagane")]
        [MaxLength(4)]        
        public ProjektOR Rok { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public ProjektOR DataWplywu { get; set; }

        public ProjektOR? Uwagi { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public List<Models.Type> Typ { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public List<OsobaPraca> OsobaProwadzaca { get; set; }

        
        public List<OsobaPraca>? OsobaZatwierdzajaca { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public List<Status> Status;


    }
}
