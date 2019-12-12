﻿using Communicator_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Repositories
{
    public interface IMessageRepository
    {
        void AddMessage(Message m);
        List<Message> UnreadMessagesFrom(string fromUser, string toUser);
        void MessageRead(List<int> ids);  
    }
}
