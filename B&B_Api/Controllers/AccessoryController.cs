using B_B_api.Data;
using Microsoft.AspNetCore.Mvc;
namespace B_B_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccessoryController : Controller
    {
        private readonly BedAndBreakfastContext _context;

        public AccessoryController(BedAndBreakfastContext context)
        {
            _context = context;
        }

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
