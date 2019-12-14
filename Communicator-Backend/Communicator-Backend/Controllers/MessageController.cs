using Communicator_Backend.Models;
using Communicator_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        [HttpPost("send/text/{toUser}")]
        [Authorize]
        public IActionResult SendMessage(string toUser, [FromBody]string contentMessage)
        {
            var fromUser = this.HttpContext.User.Identity.Name;
            
            this.messageService.AddTextMessage(fromUser, toUser, contentMessage);
            return Ok();
        }

        [HttpGet("get/unread")]
        [Authorize]
        public IActionResult GetUnreadLogins()
        {
            var user = this.HttpContext.User.Identity.Name;
            var logins = this.messageService.GetUnreadLogins(user);
            return Ok(logins);
        }

        [HttpGet("get/unread/{login}")]
        [Authorize]
        public IActionResult GetUnreadMessagesFrom(string login)
        {
            var user = this.HttpContext.User.Identity.Name;
            var messages = this.messageService.UnreadMessagesFrom(login, user);
            return Ok(messages);
        }

        [HttpGet("get/messages/{login}")]
        [Authorize]
        public IActionResult GetAllMessagesFrom(string login)
        {
            var user = this.HttpContext.User.Identity.Name;
            var messages = this.messageService.AllMessagesFrom(login, user);
            return Ok(messages);
        }

        [HttpPost("send/image/{login}")]
        [Authorize]
        public IActionResult SendImage([FromBody]int fileId, string login)
        {
            var user = this.HttpContext.User.Identity.Name;
            this.messageService.SendImage(user, login, fileId);
            return Ok();
        }

        [HttpPost("send/file/{login}")]
        [Authorize]
        public IActionResult SendFile([FromBody]int fileId, string login)
        {
            var user = this.HttpContext.User.Identity.Name;
            this.messageService.SendFile(user, login, fileId);
            return Ok();
        }
    }
}
