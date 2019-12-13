using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Services
{
    public interface IFileService
    {
        int AddFile(string path);
        string GetFile(int id);
    }
}
