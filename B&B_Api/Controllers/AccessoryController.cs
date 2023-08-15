using Microsoft.AspNetCore.Mvc;

namespace B_B_Api.Controllers
{
    [ApiController]
    [Route("controller")]
    public class AccessoryController : Controller
    {
        [HttpGet]
        [Route("Get")]
        public IActionResult Get(string id)
        {
            return Ok("Hello");
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Post(string id)
        {
            return NotFound();
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(string id)
        {
            return NotFound();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(string id)
        {
            return NotFound();
        }
    }
}
