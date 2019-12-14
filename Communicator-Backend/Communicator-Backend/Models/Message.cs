using System;
using System.Collections.Generic;

namespace Communicator_Backend.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public bool IsRead { get; set; }
        public string Content { get; set; }
        public int MessageType { get; set; }
        public int? FileId { get; set; }
        public DateTime SendTime { get; set; }

        public virtual UserFile File { get; set; }
        public virtual CommunicatorUser FromUserNavigation { get; set; }
        public virtual CommunicatorUser ToUserNavigation { get; set; }
    }
}
