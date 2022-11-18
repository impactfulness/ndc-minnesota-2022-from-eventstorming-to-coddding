using CinemaAllocations.Domain;

namespace CinemaAllocations.Adapters.DataPersistence;

public class MovieScreenings : IMovieScreenings, IDisposable
{
    private readonly MovieScreeningsContext _myContext;

    public MovieScreenings(MovieScreeningsContext myContext)
    {
        _myContext = myContext ?? throw new ArgumentNullException(nameof(myContext));
    }

    public Domain.MovieScreening FindMovieScreeningById(string screeningId)
    {
        var movieScreeningDataModel = _myContext.MovieScreenings.SingleOrDefault(x => x.Id == screeningId);

        // Given the way that InMemory is working in .NET 6, I'm forcing the load of the entities in this way.
        // Using a database technology, it will need a different query model.
        _myContext.Entry(movieScreeningDataModel).Collection(m => m.Rows).Load();
        foreach (var row in movieScreeningDataModel.Rows)
        {
            _myContext.Entry(row).Collection(r => r.Seats).Load();
        }

        return movieScreeningDataModel?.ToDomainModel();
    }

    public void Dispose()
    {
        _myContext.Dispose();
    }
}