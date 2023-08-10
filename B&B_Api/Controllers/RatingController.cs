using Microsoft.AspNetCore.Mvc;

namespace B_B_Api.Controllers
{
    [ApiController]
    [Route("controller")]
    public class RatingController : Controller
    {
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            return NotFound();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Post()
        {
            return NotFound();
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete()
        {
            return NotFound();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update()
        {
            return NotFound();
        }
    }
}
