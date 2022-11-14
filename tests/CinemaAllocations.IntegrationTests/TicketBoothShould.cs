using CinemaAllocations.Adapters.DataPersistence;
using CinemaAllocations.Domain;
using NFluent;

namespace CinemaAllocations.IntegrationTests;

public class TicketBoothShould
{
    [Fact]
    public void Reserve_one_seat_when_available()
    {
        const string showId = "1";
        const int partyRequested = 1;

        IMovieScreeningRepository repository = new MovieScreeningRepository();
        var ticketBooth = new TicketBooth(repository);

        var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(showId, partyRequested));

        Check.That(seatsAllocated.ReservedSeats).HasSize(1);
        Check.That(seatsAllocated.ReservedSeats[0].ToString()).IsEqualTo("A3");
    }
}