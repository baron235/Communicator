using Communicator_Backend.Models;
using Communicator_Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Communicator_Backend.Services
{
    public class FileService : IFileService
    {
        private readonly IUserFileRepository fileRepository;

        public FileService(IUserFileRepository fileRepository)
        {
            this.fileRepository = fileRepository;
        }
        public int AddFile(string path)
        {
            var file = new UserFile();
            file.Path = path;
            return this.fileRepository.AddFile(file);
        }

        public string GetFile(int id)
        {
            return this.fileRepository.GetFile(id).Path;
        }
    }
}
