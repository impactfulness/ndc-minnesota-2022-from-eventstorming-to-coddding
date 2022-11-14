namespace CinemaAllocations.Domain
{
    public class TicketBooth
    {
        private readonly IMovieScreeningRepository _movieScreeningRepository;
        private const int MaximumNumberOfAllowedTickets = 8;

        public TicketBooth(IMovieScreeningRepository movieScreeningRepository)
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