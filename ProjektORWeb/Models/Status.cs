using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektORWeb.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        public int id {  get; set; }
            

        public string? Nazwa { get; set; } //? = null!

         //brak warunkow
        public virtual ICollection<ProjektOR> ProjektOrs { get; set; } = new List<ProjektOR>();
    }
}
