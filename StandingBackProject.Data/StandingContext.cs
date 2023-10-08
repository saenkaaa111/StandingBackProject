using Microsoft.EntityFrameworkCore;
using StandingBackProject.Data.Entities;

namespace StandingBackProject.Data;

public class StandingContext : DbContext
{
    //public StandingContext(DbContextOptions<StandingContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=StandingDB;Integrated Security=True; TrustServerCertificate=True");       
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerTournamentsHistory>()
                    .HasOne(e => e.Person)
                    .WithMany(e => e.PlayerTournamentsHistories)
                    .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<PlayerTournamentsHistory>()
                    .HasOne(e => e.Tournament)
                    .WithMany(e => e.PlayerTournamentsHistories)
                    .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<TeamTournamentsHistory>()
                    .HasOne(e => e.Team)
                    .WithMany(e => e.TeamTournamentsHistories)
                    .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<TeamTournamentsHistory>()
                    .HasOne(e => e.Tournament)
                    .WithMany(e => e.TeamTournamentsHistories)
                    .OnDelete(DeleteBehavior.NoAction);
        
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

        modelBuilder.Entity<ResultTournamentTeam>()
                    .HasOne(e => e.Team)
                    .WithMany(e => e.ResultTournamentTeams)
                    .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<ResultTournamentTeam>()
                    .HasOne(e => e.Tournament)
                    .WithMany(e => e.ResultTournamentTeams)
                    .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<ResultTournamentTeam>()
                    .HasOne(e => e.Game)
                    .WithMany(e => e.ResultTournamentTeams)
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
        
        modelBuilder.Entity<Person>()
                    .HasOne(e => e.Team)
                    .WithMany(e => e.Persons)
                    .OnDelete(DeleteBehavior.NoAction);

        //modelBuilder.Entity<Route>()
        //            .HasOne(e => e.StartStation)
        //            .WithMany(e => e.RoutesWithStartStation);
        //modelBuilder.Entity<Route>()
        //            .HasOne(e => e.EndStation)
        //            .WithMany(e => e.RoutesWithEndStation);

        //modelBuilder.Entity<Transit>()
        //            .HasOne(e => e.StartStation)
        //            .WithMany(e => e.TransitsWithStartStation);
        //modelBuilder.Entity<Transit>()
        //            .HasOne(e => e.EndStation)
        //            .WithMany(e => e.TransitsWithEndStation);

        //modelBuilder.Entity<Ticket>()
        //            .Property(p => p.Price)
        //            .HasPrecision(9, 2);

        //modelBuilder.Entity<Transit>()
        //            .Property(p => p.Price)
        //            .HasPrecision(9, 2);
    }

    public DbSet<Club> Club { get; set; }
    public DbSet<Game> Game { get; set; }
    public DbSet<Person> Person { get; set; }
    public DbSet<PlayerTournamentsHistory> PlayerTournamentsHistory { get; set; }
    public DbSet<ResultTournamentPlayer> ResultTournamentPlayer { get; set; }
    public DbSet<ResultTournamentTeam> ResultTournamentTeam { get; set; }
    public DbSet<Team> Team { get; set; }
    public DbSet<TeamTournamentsHistory> TeamTournamentsHistory { get; set; }
    public DbSet<Tournament> Tournament { get; set; }
}


