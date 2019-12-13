using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Communicator_Backend.Models;
using Communicator_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Communicator_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService fileService;

        public FileController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetFile(int id)
        {
            var path = this.fileService.GetFile(id);
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.CopyTo(memory);
            }

            memory.Position = 0;
            return File(memory, "application/octet-stream", Path.GetFileName(path));
        }

        [Authorize]
        [HttpPost("upload")]
        public IActionResult UploadFile([FromForm]IFormFile file)
        {
            const string basePath = @"C:/server/files";

            if (file.Length > 0)
            {
                var directoryName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                var directoryPath = Path.Combine(basePath, directoryName);
                Directory.CreateDirectory(directoryPath);
                var filePath = Path.Combine(directoryPath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                var id = this.fileService.AddFile(filePath);
                return Ok(id);
            }
            return BadRequest();
        }
    }
}
