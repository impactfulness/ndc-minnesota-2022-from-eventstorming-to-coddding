namespace CinemaAllocations.Domain
{
    public interface IMovieScreenings
    {
        MovieScreening FindMovieScreeningById(string screeningId);
    }
}