namespace CinemaAllocations.Domain
{
    public class TicketBooth
    {
        private readonly IMovieScreenings _movieScreeningRepository;
        private const int MaximumNumberOfAllowedTickets = 8;

        public TicketBooth(IMovieScreenings movieScreeningRepository)
        {
            _movieScreeningRepository = movieScreeningRepository;
        }

        public SeatsAllocated AllocateSeats(AllocateSeats allocateSeats)
        {
            if (allocateSeats.PartyRequested > MaximumNumberOfAllowedTickets)
            {
                return new TooManyTicketsRequested(allocateSeats.PartyRequested);
            }

            var movieScreening = _movieScreeningRepository.FindMovieScreeningById(allocateSeats.ShowId);
            return movieScreening.AllocateSeats(allocateSeats);
        }
    }
}