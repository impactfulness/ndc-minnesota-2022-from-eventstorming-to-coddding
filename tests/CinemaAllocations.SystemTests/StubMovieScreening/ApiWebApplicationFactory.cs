using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaAllocations.SystemTests.StubMovieScreening;

public class ApiWebApplicationFactory : WebApplicationFactory<Program>
{
    private static string _databaseName;

    internal static string DatabaseName
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(_databaseName))
                return _databaseName;

            _databaseName = Guid.NewGuid().ToString();

            return _databaseName;
        }
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.AddDbContext<Adapters.DataPersistence.CinemaContext>(opt =>
                opt.UseInMemoryDatabase(DatabaseName));
        });
    }
}