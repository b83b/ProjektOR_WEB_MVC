using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjektORWeb.Models
{
    [Table("Typ")]
    public partial class Type
    {
        [Key]
        public int Id { get; set; }

        public string Typ { get; set; } = null!;

         
        




    }
}
