namespace CinemaAllocations.SystemTests.StubMovieScreening;

public abstract class SystemTests : IClassFixture<ApiWebApplicationFactory>
{
    protected readonly ApiWebApplicationFactory _factory;
    protected readonly HttpClient _client;

    protected SystemTests(ApiWebApplicationFactory fixture)
    {
        _factory = fixture;
        _client = _factory.CreateClient();
    }
}