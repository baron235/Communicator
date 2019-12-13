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
            this.context.CommunicatorUser.Add(user);
            this.context.SaveChanges();
        }

        public CommunicatorUser GetUser(string login)
        {
            return this.context.CommunicatorUser.FirstOrDefault(u => u.Login == login);
        }

        public void ModifyUser(CommunicatorUser user)
        {
            var userInDb = this.context.CommunicatorUser.FirstOrDefault(u => u.Login == user.Login);
            if(userInDb == null)
            {
                throw new Exception();
            }
            userInDb.Status = user.Status;
            userInDb.Password = user.Password;
            userInDb.Avatar = user.Avatar;
            userInDb.Name = user.Name;

            this.context.SaveChanges();
        }
    }
}
