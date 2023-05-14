using Microsoft.EntityFrameworkCore;
using System;

namespace ProjektORWeb.Models
{
    public class BzrdDbContext : DbContext //dziedziczenie po DbContext
    {
        public BzrdDbContext() 
        { 
        
        }

        public DbSet<ProjektOR> ProjektOrs { get; set; } // kolekcja - zbior elementow (reprezentuje tabelke z bazy danych)

        public DbSet<ProjektOR> Typs { get; set; }


        //string ConnectionStringWin = "Data Source=DESKTOP-BBU712F;Initial Catalog=ProjektOR;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        //string ConnectionStringSQL = "Data Source=DESKTOP-BBU712F;Initial Catalog=ProjektOR;User ID=admin;Password=********;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Constans.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
