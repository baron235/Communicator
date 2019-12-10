using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Models.JWT
{
    public class AccessToken
    {
        public DateTime ExpireOnDate { get; set; }
        public long ExpiryIn { get; set; }
        public string Token { get; set; }
        public bool Success { get; set; }
    }
}
