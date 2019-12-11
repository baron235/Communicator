using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Communicator_Backend.DTOs;
using Communicator_Backend.Repositories;

namespace Communicator_Backend.Services
{
    public class FriendsService : IFriendsService
    {
        private readonly IFriendshipRepository friendshipRepository;
        private readonly IUserRepository userRepository;

        public FriendsService(IFriendshipRepository friendshipRepository, IUserRepository userRepository)
        {
            this.friendshipRepository = friendshipRepository;
            this.userRepository = userRepository;
        }

        public void AddFriend(string login1, string login2)
        {
            var id1 = this.userRepository.GetUser(login1).Id;
            var id2 = this.userRepository.GetUser(login2).Id;

            if (this.friendshipRepository.CheckFriends(id1, id2))
            {
                throw new ArgumentException();
            }
            else
            {
                this.friendshipRepository.AddFriendship(id1, id2);
            }
        }

        public void DeleteFriend(string login1, string login2)
        {
            var id1 = this.userRepository.GetUser(login1).Id;
            var id2 = this.userRepository.GetUser(login2).Id;

            if (this.friendshipRepository.CheckFriends(id1, id2))
            {
                this.friendshipRepository.DeleteFriendship(id1, id2);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public List<UserDto> GetFriends(string login)
        {
            var id = this.userRepository.GetUser(login).Id;
            var users = this.friendshipRepository.GetFriends(id);

            return users.Select(u =>
                new UserDto()
                {
                    Login = u.Login,
                    Name = u.Name,
                    Status = u.Status
                }).ToList();
        }
    }
}
