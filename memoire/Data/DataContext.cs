using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace memoire.Models
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var builder = new ConfigurationBuilder()
        //                            .SetBasePath(Directory.GetCurrentDirectory())
        //                            .AddJsonFile("appsettings.json");
        //    var configuration = builder.Build();

        //    optionsBuilder.UseMySql(configuration["ConnectionStrings:DefaultConnection"]);

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Approvisionement>()
                .HasOne(c => c.Revendeur);

            modelBuilder.Entity<ApplicationUser>(entity => {
                entity.Property(m => m.Id).HasMaxLength(110);
                entity.Property(m => m.Email).HasMaxLength(127);
                entity.Property(m => m.NormalizedEmail).HasMaxLength(100);
                entity.Property(m => m.NormalizedUserName).HasMaxLength(100);
                entity.Property(m => m.UserName).HasMaxLength(127);
            });
            modelBuilder.Entity<IdentityRole>(entity => {
                entity.Property(m => m.Id).HasMaxLength(200);
                entity.Property(m => m.Name).HasMaxLength(127);
                entity.Property(m => m.NormalizedName).HasMaxLength(100);
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.Property(m => m.LoginProvider).HasMaxLength(100);
                entity.Property(m => m.ProviderKey).HasMaxLength(100);
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(100);
                entity.Property(m => m.RoleId).HasMaxLength(100);
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(110);
                entity.Property(m => m.LoginProvider).HasMaxLength(110);
                entity.Property(m => m.Name).HasMaxLength(110);
            });

            base.OnModelCreating(modelBuilder);
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
