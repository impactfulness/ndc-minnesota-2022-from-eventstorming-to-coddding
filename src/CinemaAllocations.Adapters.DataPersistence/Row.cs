namespace CinemaAllocations.Adapters.DataPersistence;

public class Row
{
    public string Id { get; set; }
        
    public string Name { get; set; }

    [ForeignKey("MovieScreeningId")]
    public MovieScreening MovieScreening { get; set; }

    public virtual List<Seat> Seats { get; set; }
}