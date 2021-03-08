using Microsoft.AspNetCore.Mvc;

namespace WeatherCollector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Weather : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Content("Weather");
    }
}
