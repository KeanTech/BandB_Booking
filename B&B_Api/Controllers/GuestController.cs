﻿using B_B_api.Data;
using Microsoft.AspNetCore.Mvc;

namespace B_B_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuestController : Controller
    {
        private readonly BedAndBreakfastContext _context;

        public GuestController(BedAndBreakfastContext context)
        {
            _context = context;
        }

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

        [HttpPost]
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