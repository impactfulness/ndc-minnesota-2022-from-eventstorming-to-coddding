using Microsoft.AspNetCore.Mvc;

namespace CinemaAllocations.Adapters.RestApi.Controllers;

public class MovieScreeningController : Controller
{
    private readonly ILogger<MovieScreeningController> _logger;

    public MovieScreeningController(ILogger<MovieScreeningController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [Route("moviescreening/{showId}/allocateseats/{partyRequested}")]
    public IActionResult AllocateSeats([FromQuery] string showId, [FromQuery] int partyRequested)
    {
        throw new NotImplementedException();
    }
}