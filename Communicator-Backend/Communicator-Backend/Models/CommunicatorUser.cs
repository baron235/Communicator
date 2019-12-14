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
            MessageFromUserNavigation = new HashSet<Message>();
            MessageToUserNavigation = new HashSet<Message>();
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Salt { get; set; }
        public int? Avatar { get; set; }
        public string Status { get; set; }
        public bool IsDarkTheme { get; set; }

        public virtual UserFile AvatarNavigation { get; set; }
        public virtual ICollection<Friendship> FriendshipFriend1Navigation { get; set; }
        public virtual ICollection<Friendship> FriendshipFriend2Navigation { get; set; }
        public virtual ICollection<Message> MessageFromUserNavigation { get; set; }
        public virtual ICollection<Message> MessageToUserNavigation { get; set; }
    }
}
