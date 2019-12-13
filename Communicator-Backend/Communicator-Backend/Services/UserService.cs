using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Communicator_Backend.Models;
using Communicator_Backend.Models.JWT;
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

        public void AddUser(UserIdentity us)
        {
            var user1=this.userRepository.GetUser(us.Login);

            if (user1 == null)
            {
                var user2 = new CommunicatorUser();
                user2.Login = us.Login;

                string md5Password = string.Empty;
                using (MD5 md5Hash = MD5.Create())
                {
                    md5Password = AuthService.GetMd5Hash(md5Hash, us.Password);
                }

                user2.Password = md5Password;
                user2.Name = us.Login;
                this.userRepository.AddUser(user2);
            }
            else
            {
                throw new Exception();
            }
        }

        public CommunicatorUser GetUser(string login)
        {
            return this.userRepository.GetUser(login);
        }
    }
}
