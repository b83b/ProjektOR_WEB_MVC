using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektORWeb.Models
{
    [Table("ZarzadcaDrogi")]
    public class ZarzadcaDrogi
    {
        public int Id { get; set; }

        public string Nazwa { get; set; }

        public string Adres { get; set; }

        public int Dzielnica { get; set; }

        //public virtual ICollection<ZarzadcaProjekt>Projekt_OR_id
    }
}
