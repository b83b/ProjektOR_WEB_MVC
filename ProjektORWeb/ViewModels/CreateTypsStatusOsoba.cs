using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektORWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjektORWeb.ViewModels
{
    public class CreateTypsStatusOsoba
    {

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Range(1,6000)]
        public int? NumerProjektu { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Range(2022, 2023)]
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
