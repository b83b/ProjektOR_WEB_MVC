using Microsoft.EntityFrameworkCore;

namespace ProjektORWeb.Models
{
    public class ProjektORDbContext : DbContext //dziedziczenie po DbContext
    {
        public ProjektORDbContext() 
        { 
        
        }

        public DbSet<ProjektOR> ProjektOrs { get; set; } // kolekcja - zbior elementow (reprezentuje tabelke z bazy danych)

        


        string ConnectionStringWin = "Data Source=DESKTOP-BBU712F;Initial Catalog=ProjektOR;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        string ConnectionStringSQL = "Data Source=DESKTOP-BBU712F;Initial Catalog=ProjektOR;User ID=admin;Password=********;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStringWin);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
