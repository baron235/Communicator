using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Communicator_Backend.Models;
using Communicator_Backend.Repositories;

namespace Communicator_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public CommunicatorUser GetUser(string login)
        {
            return this.userRepository.GetUser(login);
        }
    }
}
