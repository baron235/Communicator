using Communicator_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Repositories
{
    public interface IUserRepository
    {
        void AddUser(CommunicatorUser user);
        CommunicatorUser GetUser(string login);
        void ModifyUser(CommunicatorUser user);
    }
}
