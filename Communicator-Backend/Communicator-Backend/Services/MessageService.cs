using Communicator_Backend.Models;
using Communicator_Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;

        public MessageService(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
        }

        public void AddTextMessage(string fromLogin, string toLogin, string text)
        {
            var idFrom = this.userRepository.GetUser(fromLogin).Id;
            var idTo = this.userRepository.GetUser(toLogin).Id;
            
            var m = new Message();
            m.Content = text;
            m.isRead = false;
            m.FromUserId idFrom;
            // TODO dokoncz jeszcze ToUserId, SendTime i message type :p
            
            this.messageRepository.AddMessage(m);
        }
    }
}
