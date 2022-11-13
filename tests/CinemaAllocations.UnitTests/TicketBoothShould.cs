using CinemaAllocations.Domain;
using CinemaAllocations.UnitTests.StubMovieScreening;
using NFluent;

namespace CinemaAllocations.UnitTests
{
    public class TicketBoothShould
    {
        private const string FordTheaterId = "1";
        private const string DockStreetId = "3";
        private const string MadisonTheaterId = "5";

        [Fact]
        public void Reserve_one_seat_when_available()
        {
            const int partyRequested = 1;

            IMovieScreeningRepository repository = new StubMovieScreeningRepository();
            var ticketBooth = new TicketBooth(repository);

            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(FordTheaterId, partyRequested));

            Check.That(seatsAllocated.Seats).HasSize(1);
            Check.That(seatsAllocated.Seats[0].ToString()).IsEqualTo("A3");
        }

        [Fact]
        public void Return_SeatsNotAvailable_when_all_seats_are_unavailable()
        {
            Check.That(true).Equals(false);
        }

        [Fact]
        public void Return_TooManyTicketsRequested_when_9_tickets_are_requested()
        {
            Check.That(true).Equals(false);
        }
    }
}