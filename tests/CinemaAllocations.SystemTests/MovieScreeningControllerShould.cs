using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NFluent;

namespace CinemaAllocations.SystemTests;

public class MovieScreeningControllerShould : IClassFixture<WebApplicationFactory<Program>>
{
    private HttpClient Client { get; }

    public MovieScreeningControllerShould(WebApplicationFactory<Program> fixture)
    {
        Client = fixture.CreateClient();
    }

    [Fact]
    public async Task Reserve_one_seat_when_available()
    {
        var response = await Client.PostAsync($"/moviescreening/{Given.The.FordTheaterId}/allocateseats/1", null);
        Check.That(response.StatusCode).IsEqualTo(HttpStatusCode.OK);

        var seatsAllocated =
            JsonConvert.DeserializeObject<Adapters.RestApi.Dto.SeatsAllocated>(
                await response.Content.ReadAsStringAsync());
        Check.That(seatsAllocated.ReservedSeats).HasSize(1);
    }
}