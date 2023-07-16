using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using MovieTickets.Data.EntityModels;

namespace MovieTickets.Data;

public class MovieDbContext : IdentityDbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActorMovie>()
            .HasKey(k => new { k.MovieId, k.ActorId });

        modelBuilder.Entity<ActorMovie>()
            .HasOne(x => x.Movie)
            .WithMany(a => a.ActorMovies)
            .HasForeignKey(x => x.MovieId);

        modelBuilder.Entity<ActorMovie>()
            .HasOne(x => x.Actor)
            .WithMany(a => a.ActorMovies)
            .HasForeignKey(a => a.ActorId);

        modelBuilder.Entity<Movie>()
            .Property(m => m.Price)
            .HasPrecision(6, 2);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Actor> Actors { get; set; } = null!;
    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<ActorMovie> ActorMovies { get; set; } = null!;
    public DbSet<Cinema> Cinemas { get; set; } = null!; 
    public DbSet<Producer> Producers { get; set; } = null!;
}