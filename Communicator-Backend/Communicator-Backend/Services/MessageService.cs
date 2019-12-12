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

        public MessageService(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public void AddTextMessage(string fromLogin, string toLogin, string text)
        {
            var m = new Message();
            m.Content = text;
            m.IsRead = false;
            m.FromUser= fromLogin;
            m.ToUser = toLogin;
            m.SendTime = DateTime.Now;
            m.MessageType = (int)MessageType.Text;

            this.messageRepository.AddMessage(m);
        }
    }
}
