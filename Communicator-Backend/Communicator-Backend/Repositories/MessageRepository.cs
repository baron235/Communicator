using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Communicator_Backend.Models;

namespace Communicator_Backend.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context context;
        public MessageRepository()
        {
            this.context = new Context();
        }

        public void AddMessage(Message m)
        {
            this.context.Message.Add(m);
            this.context.SaveChanges();
        }

        public List<Message> UnreadMessagesFrom(string fromUser, string toUser)
        {
            return this.context.Message.Where(m => m.IsRead == false && m.FromUser == fromUser && m.ToUser == toUser).ToList();
        }

        public void MessageRead(List<int> ids)
        {
            this.context.Message.Where(m => ids.Contains(m.Id)).ToList().ForEach(m=>m.IsRead=true);
            this.context.SaveChanges();
        }

        public List<string> GetUnreadLogins(string login)
        {
            var unreadList = this.context.Message.Where(m => m.ToUser == login && m.IsRead == false).Select(m=>m.FromUser).ToList();
            return unreadList ;
        }
    }
}
