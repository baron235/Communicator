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

        public string ContentMessage(CommunicatorUser from_user)
        {
            throw new NotImplementedException();
        }

        public CommunicatorUser FromWho(int id)
        {
            return this.context.CommunicatorUser.First(u => u.Id == id);
        }
        public void AddMessage(Message m)
        {
            this.context.Message.Add(m);
            this.context.SaveChanges();
        }
    }
}
