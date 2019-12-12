using Communicator_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Repositories
{
    public interface IMessageRepository
    {
        CommunicatorUser FromWho(int id);
        string ContentMessage(CommunicatorUser from_user);
        void AddMessage(Message m);
    }
}
