using Microsoft.EntityFrameworkCore;
using ProjektORWeb.ViewModels;
using System;

namespace ProjektORWeb.Models
{
    public class BzrdDbContext : DbContext //dziedziczenie po DbContext
    {
        internal IEnumerable<object> projektTyp;

        public BzrdDbContext() 
        { 
        
        }

        public DbSet<ProjektOR> ProjektOrs { get; set; } // kolekcja - zbior elementow (reprezentuje tabelke z bazy danych)

        public DbSet<Type> Typs { get; set; }

        public DbSet<Status> Statuss { get; set; }

        public DbSet<OsobaPraca> OsobaPracas { get; set; }

        public DbSet<Stanowisko> Stanowiskoss { get; set; }

        public DbSet<Wydzial> Wydzials { get; set; }

       
                
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Constans.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }


        
    }
}
