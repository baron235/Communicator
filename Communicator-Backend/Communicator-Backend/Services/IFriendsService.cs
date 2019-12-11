using Communicator_Backend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Services
{
    public interface IFriendsService
    {
        void AddFriend(string login1, string login2);
        void DeleteFriend(string login1, string login2);
        List<UserDto> GetFriends(string login);
    }
}
