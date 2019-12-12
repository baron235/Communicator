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

        public void AddFriendship(string login1, string login2)
        {
            var friendship = new Friendship();
            friendship.Friend1 = login1;
            friendship.Friend2 = login2;
            this.context.Friendship.Add(friendship);
            this.context.SaveChanges();
        }

        public bool CheckFriends(string login1, string login2)
        {
            return this.context.Friendship.Any(f => 
            (f.Friend1 == login1 && f.Friend2 == login2) || 
            (f.Friend1 == login2 && f.Friend2 == login1));
        }
        public void DeleteFriendship(string login1, string login2)
        {
            if(this.CheckFriends(login1, login2))
            {
                var friendship = this.context.Friendship.First(f =>
                    (f.Friend1 == login1 && f.Friend2 == login2) ||
                    (f.Friend1 == login2 && f.Friend2 == login1));

                this.context.Friendship.Remove(friendship);
                this.context.SaveChanges();
            }
        }

        public List<CommunicatorUser> GetFriends(string login)
        {
            var newF1 = this.context.Friendship.Where(p => p.Friend1 == login).Select(p => p.Friend2).ToList();
            var newF2 = this.context.Friendship.Where(p => p.Friend2 == login).Select(p => p.Friend1).ToList();
            newF1.AddRange(newF2);

            return this.context.CommunicatorUser.Where(u => newF1.Contains(u.Login)).ToList();
        }
    }
}
