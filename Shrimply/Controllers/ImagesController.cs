using Microsoft.AspNetCore.Mvc;

namespace Shrimply.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("this is the images get method");
        }
    }
}
