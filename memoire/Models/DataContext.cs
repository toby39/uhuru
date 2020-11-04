using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace memoire.Models
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            optionsBuilder.UseMySql(configuration["ConnectionStrings:DefaultConnection"]);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Approvisionement>()
                .HasOne(c => c.Revendeur);
        }
        public DbSet<Client> Clients { get; set; }

        public DbSet<Revendeur> Revendeurs { get; set; }

        public DbSet<Approvisionement> Approvisionements { get; set; }

        public DbSet<Vente> Ventes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Agence> Agences { get; set; }

        public DbSet<Superuser> Superusers { get; set; }

        public DbSet<Stat> Stats { get; set; }
        public DbSet<Tarif> Tarifs { get; set; }
    }
}
