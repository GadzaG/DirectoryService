using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")] // прописал вручную, чтобы путь был с маленькой буквы
public class DepartmentsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok("Test");
    }
}