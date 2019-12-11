using Communicator_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Repositories
{
    public interface IFriendshipRepository
    {
        bool CheckFriends(int id1, int id2);
        List<CommunicatorUser> GetFriends(int id);
        void AddFriendship(int id1, int id2);
        void DeleteFriendship(int id1, int id2);
    }
}
