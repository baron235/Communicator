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
    public class FriendsController : ControllerBase
    {
        private readonly IFriendsService friendsService;

        public FriendsController(IFriendsService friendsService)
        {
            this.friendsService = friendsService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetFriends()
        {
            var login = this.HttpContext.User.Identity.Name;
            var friends = this.friendsService.GetFriends(login);
            return Ok(friends);
        }

        [Authorize]
        [HttpPost("add/{login}")]
        public IActionResult AddFriends(string login)
        {
            var user1 = this.HttpContext.User.Identity.Name;
            if(user1==login)
            {
                return BadRequest("Cant add yourself to friends");
            }
            else
            {
                try
                {
                    this.friendsService.AddFriend(user1, login);
                    return Ok();
                }
                catch (ArgumentException)
                {
                    // Already friends
                    return NoContent();
                }
            }
        }
        [Authorize]
        [HttpDelete("delete/{login}")]
        public IActionResult DeleteFriend(string login)
        {
            var user1 = this.HttpContext.User.Identity.Name;
            if (user1 == login)
            {
                return BadRequest("Cant delete yourself");
            }
            else
            {
                try
                {
                    this.friendsService.DeleteFriend(user1, login);
                    return Ok();
                }
                catch (ArgumentException)
                {
                    return NoContent();
                }
            }
        }
    }
}
