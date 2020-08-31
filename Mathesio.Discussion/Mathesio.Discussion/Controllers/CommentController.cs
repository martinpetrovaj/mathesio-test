using Microsoft.AspNetCore.Mvc;

namespace Mathesio.Discussion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult("Hello World");
        }
    }
}