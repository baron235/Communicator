using System;
using System.Collections.Generic;

namespace Communicator_Backend.Models
{
    public partial class CommunicatorUser
    {
        public CommunicatorUser()
        {
            FriendshipFriend1Navigation = new HashSet<Friendship>();
            FriendshipFriend2Navigation = new HashSet<Friendship>();
            MessageFromUser = new HashSet<Message>();
            MessageToUser = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Friendship> FriendshipFriend1Navigation { get; set; }
        public virtual ICollection<Friendship> FriendshipFriend2Navigation { get; set; }
        public virtual ICollection<Message> MessageFromUser { get; set; }
        public virtual ICollection<Message> MessageToUser { get; set; }
    }
}
