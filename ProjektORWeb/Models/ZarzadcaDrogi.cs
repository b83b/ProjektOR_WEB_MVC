using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektORWeb.Models
{
    [Table("ZarzadcaDrogi")]
    public class ZarzadcaDrogi
    {
        [Key]
        public int Id { get; set; }

        public string Nazwa { get; set; }

        public string Adres { get; set; }

        public int Dzielnica { get; set; }

        public virtual ICollection<ProjektOR> ProjektOrs { get; set; } 
    }
}
