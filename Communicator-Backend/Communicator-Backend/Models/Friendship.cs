using System;
using System.Collections.Generic;

namespace Communicator_Backend.Models
{
    public partial class Friendship
    {
        public int Id { get; set; }
        public string Friend1 { get; set; }
        public string Friend2 { get; set; }

        public virtual CommunicatorUser Friend1Navigation { get; set; }
        public virtual CommunicatorUser Friend2Navigation { get; set; }
    }
}
