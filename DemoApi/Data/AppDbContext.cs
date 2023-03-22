using DemoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=DemoApiTest;Trusted_Connection=True;TrustServerCertificate=True;");

        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property(i => i.Name).HasMaxLength(50);

        base.OnModelCreating(modelBuilder);
    }
}
