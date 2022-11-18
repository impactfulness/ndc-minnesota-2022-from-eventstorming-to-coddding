using Microsoft.EntityFrameworkCore;

namespace CinemaAllocations.Adapters.DataPersistence;

public class MovieScreeningsContext : DbContext
{
    public DbSet<MovieScreening> MovieScreenings { get; set; }
    public DbSet<Row> Rows { get; set; }
    public DbSet<Seat> Seats { get; set; }

    public MovieScreeningsContext(DbContextOptions<MovieScreeningsContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<Seat>()
            .HasOne(s => s.Row)
            .WithMany(r => r.Seats);

        // modelBuilder
        //     .Entity<Row>()
        //     .HasMany<Seat>();
    }
}