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

        [HttpPost("add/{toUser}")]
        [Authorize]
        public void SendMessage(string toUser, [FromBody]string contentMessage)
        {
            var fromUser = this.HttpContext.User.Identity.Name;
            
            var m = this.messageService.AddTextMessage(fromUser, toUser, contentMessage);

        }
    }
}
