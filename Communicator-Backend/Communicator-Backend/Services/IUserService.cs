using Communicator_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Services
{
    public interface IUserService
    {
        CommunicatorUser GetUser(string login);

    }
}
