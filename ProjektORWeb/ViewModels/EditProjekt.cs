using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektORWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ProjektORWeb.ViewModels
{
    public class EditProjekt
    {

        public  int id { get; set; }

        public int? NumerProjektu { get; set; }

        public int? Rok { get; set; }

        public DateTime DataWplywu { get; set; }

       

        public string? Uwagi { get; set; }

        public int TypId { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public int OsobaProwadzacaId { get; set; }

        public int? OsobaZatwierdzajacaId { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public int? StatusId { get; set; }

       
        //============================        

        public ProjektOR? ProjektORs { get; set; }

        //==============================

        public List<SelectListItem>? Typ { get; set; }
        public List<SelectListItem>? OsobaProwadzaca { get; set; }


        public List<SelectListItem>? OsobaZatwierdzajaca { get; set; }

        public List<SelectListItem>? Status { get; set; }
    }
}
