using Microsoft.AspNetCore.Mvc;

namespace Reminder.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello, world!");
        }
    }
}