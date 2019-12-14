using Communicator_Backend.DTOs;
using Communicator_Backend.Models;
using Communicator_Backend.Models.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Services
{
    public interface IUserService
    {
        UserDto GetUser(string login);
        void AddUser(UserIdentity login);
        void SetAvatar(string login,int id);
        void SetStatus(string login, string status);





    }
}
