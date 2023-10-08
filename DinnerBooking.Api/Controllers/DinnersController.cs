using Microsoft.AspNetCore.Mvc;


namespace DinnerBooking.Api.Controllers;

[Route("api/dinners")]
public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}