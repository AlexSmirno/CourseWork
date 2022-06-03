using Microsoft.EntityFrameworkCore;
using WebServer.Data.Models;

namespace WebServer.Data
{
    public class StorageContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseNpgsql(@"Host=localhost;Database=Storage;Username=postgres;Password=admin")
                .UseSnakeCaseNamingConvention()
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Supply>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Supplier>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Client>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Supply>().HasMany(sup => sup.Products).WithOne(prod => prod.Supply);
            modelBuilder.Entity<Supplier>().HasMany(sup => sup.Supplies).WithOne(supply => supply.Supplier);
            modelBuilder.Entity<Client>().HasMany(cl => cl.Supplies).WithOne(sup => sup.Client);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
