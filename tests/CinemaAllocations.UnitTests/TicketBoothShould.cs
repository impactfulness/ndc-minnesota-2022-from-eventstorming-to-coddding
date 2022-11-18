using CinemaAllocations.Domain;
using CinemaAllocations.UnitTests.StubMovieScreening;
using NFluent;

namespace CinemaAllocations.UnitTests
{
    public class TicketBoothShould
    {
        private const string FordTheaterId = "1";
        private const string O3AuditoriumId = "2";
        private const string DockStreetId = "3";
        private const string MadisonTheaterId = "5";

        [Fact]
        public void Reserve_one_seat_when_available()
        {
            const int partyRequested = 1;

            IMovieScreenings movieScreenings = new StubMovieScreenings();
            var ticketBooth = new TicketBooth(movieScreenings);

            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(FordTheaterId, partyRequested));

            Check.That(seatsAllocated.ReservedSeats).HasSize(1);
            Check.That(seatsAllocated.ReservedSeats[0].ToString()).IsEqualTo("A3");
        }

        [Fact]
        public void Reserve_multiple_seats_when_available()
        {
            const int partyRequested = 3;

            IMovieScreenings repository = new StubMovieScreenings();
            var ticketBooth = new TicketBooth(repository);

            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(DockStreetId, partyRequested));

            Check.That(seatsAllocated.ReservedSeats).HasSize(3);
            Check.That(seatsAllocated.ReservedSeats[0].ToString()).IsEqualTo("A6");
            Check.That(seatsAllocated.ReservedSeats[1].ToString()).IsEqualTo("A7");
            Check.That(seatsAllocated.ReservedSeats[2].ToString()).IsEqualTo("A8");
        }

        [Fact]
        public void Return_SeatsNotAvailable_when_all_seats_are_unavailable()
        {
            const int partyRequested = 1;

            IMovieScreenings repository = new StubMovieScreenings();
            var ticketBooth = new TicketBooth(repository);

            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(MadisonTheaterId, partyRequested));

            Check.That(seatsAllocated).IsInstanceOf<NoPossibleAllocationsFound>();
        }

        [Fact]
        public void Return_TooManyTicketsRequested_when_9_tickets_are_requested()
        {
            const int partyRequested = 9;

            IMovieScreenings repository = new StubMovieScreenings();
            var ticketBooth = new TicketBooth(repository);

            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(MadisonTheaterId, partyRequested));

            Check.That(seatsAllocated).IsInstanceOf<TooManyTicketsRequested>();
        }

        [Fact]
        public void Reserve_three_adjacent_seats_when_available()
        {
            const int partyRequested = 3;

            IMovieScreenings repository = new StubMovieScreenings();
            var ticketBooth = new TicketBooth(repository);

            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(O3AuditoriumId, partyRequested));

            Check.That(seatsAllocated.ReservedSeats).HasSize(3);
            Check.That(seatsAllocated.SeatNames()).ContainsExactly("A8", "A9", "A10");
        }

        [Fact]
        public void Return_NoPossibleAdjacentSeatsFound_when_4_tickets_are_requested()
        {
            const int partyRequested = 4;

            IMovieScreenings repository = new StubMovieScreenings();
            var ticketBooth = new TicketBooth(repository);

            var seatsAllocated = ticketBooth.AllocateSeats(new AllocateSeats(O3AuditoriumId, partyRequested));

            Check.That(seatsAllocated).IsInstanceOf<NoPossibleAdjacentSeatsFound>();
        }
    }
}