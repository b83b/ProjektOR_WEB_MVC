using ProjektORWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjektORWeb.ViewModels
{
    public class CreateTypsStatusOsoba
    {
        
        [Required(ErrorMessage = "Pole jest wymagane")]
        public int? NumerProjektu { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        //[MaxLength(4)]        
        public int? Rok { get; set; } 

        [Required(ErrorMessage = "Pole jest wymagane")]
        public DateTime DataWplywu { get; set; }

        public string? Uwagi { get; set; }


        public int TypId { get; set; }

        public int OsobaProwadzacaId { get; set; }

        public int OsobaZatwierdzajacaId { get; set; }

        public int StatusId { get; set; } 




        public List<Models.Type>? Typ { get; set; }

        
        public List<OsobaPraca>? OsobaProwadzaca { get; set; }

        
        public List<OsobaPraca>? OsobaZatwierdzajaca { get; set; }

        
        public List<Status>? Status { get; set; }


    }
}
