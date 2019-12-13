using Communicator_Backend.Models;
using Communicator_Backend.Models.JWT;
using Communicator_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Communicator_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("add")]
        public IActionResult CreateNewUser([FromBody]UserIdentity user)
        {
            try
            {
                this.userService.AddUser(user);
                return Ok();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
    }
}
