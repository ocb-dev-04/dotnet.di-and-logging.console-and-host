using ConsoleWorkerFullTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleWorkerFullTest.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    public DbSet<Profile> Profiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=test_database;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
