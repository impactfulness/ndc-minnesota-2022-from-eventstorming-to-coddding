namespace CinemaAllocations.UnitTests.StubMovieScreening;

public class MovieScreeningDto
{
    public Dictionary<string, IReadOnlyList<SeatDto>> Rows { get; set; }
}