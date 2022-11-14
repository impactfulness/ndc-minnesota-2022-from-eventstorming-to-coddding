using CinemaAllocations.Domain;

namespace CinemaAllocations.Adapters.DataPersistence;

public class MovieScreeningRepository : IMovieScreeningRepository, IDisposable
{
    private readonly CinemaContext _cinemaContext;

    public MovieScreeningRepository(CinemaContext cinemaContext)
    {
        _cinemaContext = cinemaContext ?? throw new ArgumentNullException(nameof(cinemaContext));
    }

    public Domain.MovieScreening FindMovieScreeningById(string screeningId)
    {
        var movieScreeningDataModel = _cinemaContext.MovieScreenings.SingleOrDefault(x => x.Id == screeningId);

        return movieScreeningDataModel?.ToDomainModel();
    }

    public void Dispose()
    {
        _cinemaContext?.Dispose();
    }
}