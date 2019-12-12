using System;
using System.Collections.Generic;

namespace Communicator_Backend.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public bool? IsRead { get; set; }
        public string Content { get; set; }
        public string MessageType { get; set; }
        public string ContentLink { get; set; }
        public DateTime? SendTime { get; set; }

        public virtual CommunicatorUser FromUser { get; set; }
        public virtual CommunicatorUser ToUser { get; set; }
    }
}
