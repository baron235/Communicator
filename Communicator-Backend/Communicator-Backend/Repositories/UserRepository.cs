using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Communicator_Backend.Models;

namespace Communicator_Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context context;

        public UserRepository()
        {
            this.context = new Context();
        }

        public void AddUser(CommunicatorUser user)
        {
            throw new NotImplementedException();
        }

        public CommunicatorUser GetUser(string login)
        {
            return this.context.CommunicatorUser.FirstOrDefault(u => u.Login == login);
        }

        public void ModifyUser(CommunicatorUser user)
        {
            throw new NotImplementedException();
        }
    }
}
