using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using MovieTickets.Data.EntityModels;

using System.Reflection;

namespace MovieTickets.Data;

public class MovieDbContext : IdentityDbContext<ApplicationUser>
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Assembly configAssembly =  Assembly.GetAssembly(typeof(MovieDbContext)) ??
            Assembly.GetExecutingAssembly();
        modelBuilder.ApplyConfigurationsFromAssembly(configAssembly);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Actor> Actors { get; set; } = null!;
    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<ActorMovie> ActorMovies { get; set; } = null!;
    public DbSet<Cinema> Cinemas { get; set; } = null!; 
    public DbSet<Producer> Producers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<ShoppingCartItems> ShoppingCartItems { get; set; } = null!;
}