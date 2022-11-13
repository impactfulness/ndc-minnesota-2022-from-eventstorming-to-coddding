namespace CinemaAllocations.UnitTests.StubMovieScreening;

public class SeatDto
{
    public string Name { get; }
    public string SeatAvailability { get; }
    
    public SeatDto(string name, string seatAvailability)
    {
        Name = name;
        SeatAvailability = seatAvailability;
    }
}