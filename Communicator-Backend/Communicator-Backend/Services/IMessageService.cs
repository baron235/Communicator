using Communicator_Backend.DTOs;
using Communicator_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Services
{
    public interface IMessageService
    {
        void AddTextMessage(string fromLogin, string toLogin, string text);
        void SendFile(string fromLogin, string toLogin, int fileId);
        void SendImage(string fromLogin, string toLogin, int imageId);

        List<string> GetUnreadLogins(string login);
        List<MessageDto> UnreadMessagesFrom(string fromUser, string toUser);
        List<MessageDto> AllMessagesFrom(string fromUser, string toUser);
    }
}
