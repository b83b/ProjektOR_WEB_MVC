using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektORWeb.Models
{
    [Table("Status")]
    public class Status
    {
        public int id {  get; set; }
            

        public string? Nazwa { get; set; } //? = null!

         
        public virtual ICollection<ProjektOR> ProjektOrs { get; set; } = new List<ProjektOR>();
    }
}
