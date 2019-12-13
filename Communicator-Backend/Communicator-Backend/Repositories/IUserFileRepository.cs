using Communicator_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Repositories
{
    public interface IUserFileRepository
    {
        void AddFile(UserFile file);
        UserFile GetFile(int id);

    }
}
