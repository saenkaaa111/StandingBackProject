using Microsoft.EntityFrameworkCore;
using StandingBackProject.Data.Entities;

namespace StandingBackProject.Data;

public class StandingContext : DbContext
{
    public StandingContext(DbContextOptions<StandingContext> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=StandingDB;Integrated Security=True; TrustServerCertificate=True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ResultTournamentPlayer>()
                    .HasOne(e => e.Person)
                    .WithMany(e => e.ResultTournamentPlayers)
                    .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<ResultTournamentPlayer>()
                    .HasOne(e => e.Tournament)
                    .WithMany(e => e.ResultTournamentPlayers)
                    .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<ResultTournamentPlayer>()
                    .HasOne(e => e.Game)
                    .WithMany(e => e.ResultTournamentPlayers)
                    .OnDelete(DeleteBehavior.NoAction);
                         
        modelBuilder.Entity<Tournament>()
                    .HasOne(e => e.Club)
                    .WithMany(e => e.Tournaments)
                    .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Tournament>()
                    .HasOne(e => e.Game)
                    .WithMany(e => e.Tournaments)
                    .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Tournament>()
                    .HasOne(e => e.Judge)
                    .WithMany(e => e.Tournaments)
                    .OnDelete(DeleteBehavior.NoAction);
               
        
    }

    public DbSet<Club> Club { get; set; }
    public DbSet<Game> Game { get; set; }
    public DbSet<Person> Person { get; set; }
    public DbSet<ResultTournamentPlayer> ResultTournamentPlayer { get; set; }
    public DbSet<Tournament> Tournament { get; set; }
}


