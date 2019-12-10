using Communicator_Backend.Models.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Services
{
    public interface IAuthService
    {
        AccessToken GetToken(UserIdentity identity);
    }
}
