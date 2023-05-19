using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektORWeb.Models
{
    [Table("Typ")]
    public partial class Type
    {
        public int Id { get; set; } 
        
        public string? Typ { get; set; } //? = null!

        //z automatu szuka TypId 
        //public List<ProjektOR> ProjektOR { get; set; } = new List<ProjektOR>();




    }
}
