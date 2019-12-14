using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.DTOs
{
    public class UserDto
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int? Avatar { get; set; }
    }
}
