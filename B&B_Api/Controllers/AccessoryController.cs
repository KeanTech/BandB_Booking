﻿using Microsoft.AspNetCore.Mvc;

namespace B_B_Api.Controllers
{
    [ApiController]
    [Route("controller")]
    public class AccessoryController : Controller
    {
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            return Ok("Hello");
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