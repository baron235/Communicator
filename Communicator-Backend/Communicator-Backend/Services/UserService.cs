using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Communicator_Backend.DTOs;
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
                user2.Salt = Guid.NewGuid().ToString();
                var toHash = $"{us.Password}{user2.Salt}";

                string md5Password = string.Empty;
                using (MD5 md5Hash = MD5.Create())
                {
                    md5Password = AuthService.GetMd5Hash(md5Hash, toHash);
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

        public UserDto GetUser(string login)
        {
            var user= this.userRepository.GetUser(login);
            if(user==null)
            {
                return null;
            }

            return new UserDto()
                {
                    Login = user.Login,
                    Name = user.Name,
                    Status = user.Status,
                    Avatar = user.Avatar
                };
        }

        public void SetAvatar(string login, int avatarId)
        {
            var user=this.userRepository.GetUser(login);
            user.Avatar = avatarId;
            this.userRepository.ModifyUser(user);
        }

        public void SetStatus(string login, string status)
        {
            var user = this.userRepository.GetUser(login);
            user.Status = status;
            this.userRepository.ModifyUser(user);
        }
    }
}
