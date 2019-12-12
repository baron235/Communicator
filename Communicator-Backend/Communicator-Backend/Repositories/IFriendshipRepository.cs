using Communicator_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Repositories
{
    public interface IFriendshipRepository
    {
        bool CheckFriends(string login1, string login2);
        List<CommunicatorUser> GetFriends(string login);
        void AddFriendship(string login1, string login2);
        void DeleteFriendship(string login1, string login2);
    }
}
