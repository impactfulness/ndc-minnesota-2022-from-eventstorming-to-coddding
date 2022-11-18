namespace CinemaAllocations.Domain
{
    public class TicketBooth
    {
        private readonly IMovieScreenings _movieScreenings;
        private const int MaximumNumberOfAllowedTickets = 8;

        public TicketBooth(IMovieScreenings movieScreenings)
        {
            _movieScreenings = movieScreenings;
        }

        public SeatsAllocated AllocateSeats(AllocateSeats allocateSeats)
        {
            if (allocateSeats.PartyRequested > MaximumNumberOfAllowedTickets)
            {
                return new TooManyTicketsRequested(allocateSeats.PartyRequested);
            }

            var movieScreening = _movieScreenings.FindMovieScreeningById(allocateSeats.ShowId);
            return movieScreening.AllocateSeats(allocateSeats);
        }
    }
}