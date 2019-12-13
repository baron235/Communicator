using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Communicator_Backend.Models;

namespace Communicator_Backend.Repositories
{
    public class UserFileRepository : IUserFileRepository
    {
        private readonly Context context;

        public UserFileRepository()
        {
            this.context = new Context();
        }

        public int AddFile(UserFile file)
        {
            this.context.UserFile.Add(file);
            this.context.SaveChanges();
            return file.Id;
        }

        public UserFile GetFile(int id)
        {
            return this.context.UserFile.FirstOrDefault(f=> f.Id==id);
        }
    }
}
