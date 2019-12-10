using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Communicator_Backend.Models;
using Communicator_Backend.Models.JWT;
using Communicator_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Communicator_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        [Route("token")]
        public IActionResult GenerateToken([FromBody]UserIdentity credentials)
        {
            try
            {
                var token = this.authService.GetToken(credentials);
                return Ok(token);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}
