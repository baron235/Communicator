using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Communicator_Backend.Models;

namespace Communicator_Backend.Repositories
{
    public class FriendshipRepository : IFriendshipRepository
    {
        private readonly Context context;

        public FriendshipRepository()
        {
            this.context = new Context();
        }

        public void AddFriendship(int id1, int id2)
        {
            var friendship = new Friendship();
            friendship.Friend1 = id1;
            friendship.Friend2 = id2;
            this.context.Friendship.Add(friendship);
            this.context.SaveChanges();
        }

        public bool CheckFriends(int id1, int id2)
        {
            return this.context.Friendship.Any(f => 
            (f.Friend1 == id1 && f.Friend2 == id2) || 
            (f.Friend1 == id2 && f.Friend2 == id1));
        }
        public void DeleteFriendship(int id1, int id2)
        {
            if(this.CheckFriends(id1, id2))
            {
                var friendship = this.context.Friendship.First(f =>
                    (f.Friend1 == id1 && f.Friend2 == id2) ||
                    (f.Friend1 == id2 && f.Friend2 == id1));

                this.context.Friendship.Remove(friendship);
                this.context.SaveChanges();
            }
        }

        public List<CommunicatorUser> GetFriends(int id)
        {
            List<int> newF1 = this.context.Friendship.Where(p => p.Friend1 == id).Select(p => p.Friend2).ToList();
            List<int> newF2 = this.context.Friendship.Where(p => p.Friend2 == id).Select(p => p.Friend1).ToList();
            newF1.AddRange(newF2);

            return this.context.CommunicatorUser.Where(u => newF1.Contains(u.Id)).ToList();
        }
    }
}
