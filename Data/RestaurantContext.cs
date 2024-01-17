using Microsoft.EntityFrameworkCore;
using GestiuneRestaurant.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GestiuneRestaurant.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<Masa> Mese { get; set; }
        public DbSet<Rezervare> Rezervari { get; set; }
        public DbSet<ProdusMeniu> ProduseMeniu { get; set; }
        public DbSet<Comanda> Comenzi { get; set; }
        public DbSet<ArticolComandat> ArticoleComandate { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);



            //Configuratia pentru relatia one-to-many 
            modelBuilder.Entity<Masa>()
         .HasMany(m => m.Rezervari)
         .WithOne(r => r.Masa)
         .HasForeignKey(r => r.MasaId);

            // Configurarea relației one-to-one între Masa și Comanda
            modelBuilder.Entity<Masa>()
                .HasOne(m => m.Comanda)
                .WithOne(c => c.Masa)
                .HasForeignKey<Comanda>(c => c.MasaId);

            // Configurarea relației one-to-many între Comanda și ArticolComandat
            modelBuilder.Entity<Comanda>()
                .HasMany(c => c.ArticoleComandate)
                .WithOne(ac => ac.Comanda)
                .HasForeignKey(ac => ac.ComandaId);

            // Configurarea relației many-to-one între ArticolComandat și ProdusMeniu
            modelBuilder.Entity<ArticolComandat>()
                .HasOne(ac => ac.ProdusMeniu)
                .WithMany(p => p.ArticoleComandate)
                .HasForeignKey(ac => ac.ProdusMeniuId);

            modelBuilder.Entity<Masa>().HasData(
        new Masa { MasaId = 1, Numar = 1, Capacitate = 6 },
        new Masa { MasaId = 2, Numar = 2, Capacitate = 6 },
        new Masa { MasaId = 3, Numar = 3, Capacitate = 6 },
        new Masa { MasaId = 4, Numar = 4, Capacitate = 6 },
        new Masa { MasaId = 5, Numar = 5, Capacitate = 6 },
        new Masa { MasaId = 6, Numar = 6, Capacitate = 6 }
    );

        }
    }
}
