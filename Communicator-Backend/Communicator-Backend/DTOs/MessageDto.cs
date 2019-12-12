using Communicator_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.DTOs
{
    public class MessageDto
    {
        public string ToUser { get; set; }
        public string FromUser { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public MessageType MessageType { get; set; }
        public int FileId { get; set; }
    }
}
