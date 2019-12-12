using Communicator_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.DTOs
{
    public class MessageDto
    {//todo........
        string toUser(CommunicatorUser user);
        string fromUser(CommunicatorUser user);
        string content();
        string sendDate();

    }
}
