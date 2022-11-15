using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaAllocations.Adapters.DataPersistence;

public sealed class Row
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    [ForeignKey("MovieScreeningId")] 
    public MovieScreening? MovieScreening { get; set; }

    public List<Seat> Seats { get; set; } = null!;
}