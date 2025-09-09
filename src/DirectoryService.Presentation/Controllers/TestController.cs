using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }
}