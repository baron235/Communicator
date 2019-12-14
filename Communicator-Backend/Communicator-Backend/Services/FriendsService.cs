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

        public FriendsService(IFriendshipRepository friendshipRepository)
        {
            this.friendshipRepository = friendshipRepository;
        }

        public void AddFriend(string login1, string login2)
        {
            if (this.friendshipRepository.CheckFriends(login1, login2))
            {
                throw new ArgumentException();
            }
            else
            {
                this.friendshipRepository.AddFriendship(login1, login2);
            }
        }

        public void DeleteFriend(string login1, string login2)
        {
            if (this.friendshipRepository.CheckFriends(login1, login2))
            {
                this.friendshipRepository.DeleteFriendship(login1, login2);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public List<UserDto> GetFriends(string login)
        {
            var users = this.friendshipRepository.GetFriends(login);

            return users.Select(u =>
                new UserDto()
                {
                    Login = u.Login,
                    Name = u.Name,
                    Status = u.Status,
                    Avatar=u.Avatar
                }).ToList();
        }
    }
}
