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

        [Authorize]
        [HttpGet("get")]
        public IActionResult GetUser()
        {
            var userDTO=this.userService.GetUser(this.HttpContext.User.Identity.Name);
            return Ok(userDTO);
        }

        [Authorize]
        [HttpGet("get/{login}")]
        public IActionResult GetUser(string login)
        {
            var userDTO=this.userService.GetUser(login);
            if(userDTO==null)
            {
                return NotFound();
            }
            return Ok(userDTO);
        }

        [Authorize]
        [HttpPost("set/avatar/{avatarId}")]
        public IActionResult SetAvatar(int avatarId)
        {
            var user=this.HttpContext.User.Identity.Name;
            this.userService.SetAvatar(user,avatarId);
            return Ok();
        }

        [Authorize]
        [HttpPost("set/status/{status}")]
        public IActionResult SetStatus(string status)
        {
            var user = this.HttpContext.User.Identity.Name;
            this.userService.SetStatus(user, status);
            return Ok();
        }
    }
}
