using Communicator_Backend.DTOs;
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

        public List<MessageDto> AllMessagesFrom(string fromUser, string toUser)
        {
            var messages=this.messageRepository.AllMessagesFrom(fromUser, toUser);

            return messages.Select(m=>
                            new MessageDto()
                            {
                                FromUser=m.FromUser,
                                ToUser=m.ToUser,
                                Content=m.Content,
                                FileId=m.FileId,
                                MessageType=(MessageType)m.MessageType,
                                SendDate=m.SendTime

                            }).ToList();
        }

        public List<string> GetUnreadLogins(string login)
        {
            return this.messageRepository.GetUnreadLogins(login);
        }

        public void SendFile(string fromLogin, string toLogin, int fileId)
        {
            var m = new Message();
            m.Content = string.Empty;
            m.IsRead = false;
            m.FromUser = fromLogin;
            m.ToUser = toLogin;
            m.SendTime = DateTime.Now;
            m.MessageType = (int)MessageType.File;
            m.FileId = fileId;

            this.messageRepository.AddMessage(m);
        }

        public void SendImage(string fromLogin, string toLogin, int imageId)
        {
            var m = new Message();
            m.Content = string.Empty;
            m.IsRead = false;
            m.FromUser = fromLogin;
            m.ToUser = toLogin;
            m.SendTime = DateTime.Now;
            m.MessageType = (int)MessageType.Image;
            m.FileId = imageId;

            this.messageRepository.AddMessage(m);
        }

        public List<MessageDto> UnreadMessagesFrom(string fromUser, string toUser)
        {
            var messages = this.messageRepository.UnreadMessagesFrom(fromUser, toUser);

            return messages.Select(m =>
                            new MessageDto()
                            {
                                FromUser = m.FromUser,
                                ToUser = m.ToUser,
                                Content = m.Content,
                                FileId = m.FileId,
                                MessageType = (MessageType)m.MessageType,
                                SendDate = m.SendTime

                            }).ToList();
        }
    }
}
