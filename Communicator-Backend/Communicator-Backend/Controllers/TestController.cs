using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Communicator_Backend.Models;
using Communicator_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Communicator_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [Authorize]
        [HttpGet("test")]
        public IActionResult Get()
        {
            return Ok(this.HttpContext.User.Identity.Name);
        }
    }
}
