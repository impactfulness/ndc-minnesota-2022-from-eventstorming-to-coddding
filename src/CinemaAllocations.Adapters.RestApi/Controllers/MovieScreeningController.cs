using Microsoft.AspNetCore.Mvc;

namespace CinemaAllocations.Adapters.RestApi.Controllers;

[ApiController]
public class MovieScreeningController : ControllerBase
{
    private readonly ILogger<MovieScreeningController> _logger;

    public MovieScreeningController(ILogger<MovieScreeningController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [Route("moviescreening/{showId}/allocateseats/{partyRequested}")]
    public IActionResult AllocateSeats(string showId, int partyRequested)
    {
        throw new NotImplementedException();
    }
}