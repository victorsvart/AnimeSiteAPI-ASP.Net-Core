namespace WebApi.Helpers;

using AnimeAPI.Models;
using Microsoft.EntityFrameworkCore;


public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server with connection string from app settings
        if (!options.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anime>()
            .HasKey(X => X.Id);
    }

    public DbSet<Anime> Animes { get; set; }
}
