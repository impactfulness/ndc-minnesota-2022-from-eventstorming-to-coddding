using CinemaAllocations.Domain;
using NFluent;

namespace CinemaAllocations.UnitTests.StubMovieScreening;

public class StubMovieScreeningShould
{
    [Fact]
    public void Find_movie_screening_one()
    {
        IMovieScreenings repository = new StubMovieScreenings();

        var movieScreening = repository.FindMovieScreeningById("1");

        Check.That(movieScreening).IsNotNull();
        Check.That(movieScreening.Rows.Count).IsEqualTo(2);
    }
}