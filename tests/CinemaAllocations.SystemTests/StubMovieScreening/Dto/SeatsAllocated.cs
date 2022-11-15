namespace CinemaAllocations.SystemTests.StubMovieScreening.Dto;

public class SeatsAllocated
{
    public int PartyRequested { get; set; }

    public List<Seat> ReservedSeats { get; set; }

    public IEnumerable<string> SeatNames()
    {
        return ReservedSeats.OrderBy(seat => seat.Number).Select(seat => seat.SeatName);
    }
}