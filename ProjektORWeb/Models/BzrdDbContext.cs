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

        //public DbSet<ProjektOR> Typs { get; set; }
        public DbSet<Type> Typs { get; set; }


        //string ConnectionStringWin = "Data Source=DESKTOP-BBU712F;Initial Catalog=ProjektOR;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        //string ConnectionStringSQL = "Data Source=DESKTOP-BBU712F;Initial Catalog=ProjektOR;User ID=admin;Password=********;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Constans.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }


        ////JEDEN DO WIELU!!!!!!!!!!!!!!!!!!!!!!!!!!
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Type>(eb =>
        //    {
        //        eb.HasMany(t => t.ProjektOR)
        //         .WithOne(p => p.Typ)
        //         .HasForeignKey(p => p.TypId);
        //    });
        //}

        //OK - moze tez byc w TYP
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProjektOR>(entity =>
        //    {
        //        entity.HasOne(d => d.TypNavigation).WithMany(p => p.ProjektOrs)
        //        .HasForeignKey(d => d.Typ)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("Projekt_OR_Typ");
        //    });
        //}
    }
}
