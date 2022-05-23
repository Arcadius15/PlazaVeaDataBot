using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotPlazaVea.Modelos
{
    public class PlazaVeaContext : DbContext
    {

        public DbSet<Productos> Productos { get; set; }
        public DbSet<Urls> Urls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Urls>()
                .HasOne(a => a.Producto)
                .WithOne(b => b.Url)
                .HasForeignKey<Productos>(b => b.idUrl);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost:5432;Database=PlazaVeaData;Username=postgres;Password=admin");
    }
}
