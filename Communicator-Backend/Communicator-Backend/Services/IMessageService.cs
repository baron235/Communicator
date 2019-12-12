using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Services
{
    public interface IMessageService
    {
        void AddTextMessage(string fromLogin, string toLogin, string text);
    }
}
