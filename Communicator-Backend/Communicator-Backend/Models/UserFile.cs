using System;
using System.Collections.Generic;

namespace Communicator_Backend.Models
{
    public partial class UserFile
    {
        public UserFile()
        {
            CommunicatorUser = new HashSet<CommunicatorUser>();
            Message = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Path { get; set; }

        public virtual ICollection<CommunicatorUser> CommunicatorUser { get; set; }
        public virtual ICollection<Message> Message { get; set; }
    }
}
