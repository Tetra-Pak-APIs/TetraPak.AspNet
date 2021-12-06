using System.IO;
using Microsoft.AspNetCore.Http;

namespace demo.Acme.Models
{
    public class FileModel : Model
    {
        readonly string _filePath;
        IFormFile? _formFile;
        
        public string ContentType { get; }
        public IFormFile? File => _formFile ??= makeFormFile();

        IFormFile? makeFormFile()
        {
            var fileInfo = new FileInfo(_filePath);
            if (!fileInfo.Exists)
                return null;

            var stream = fileInfo.OpenRead();
            return new FormFile(stream, 0, stream.Length, "file", Path.GetFileName(stream.Name))
            {
                Headers = new HeaderDictionary(),
                ContentType = ContentType
            };
        }

        public FileModel(string? id, IFormFile formFile) 
        : this(id, new FileInfo(formFile.FileName), formFile.ContentType)
        {
            _formFile = formFile;
        }
        
        public FileModel(string? id, FileSystemInfo fileInfo, string contentType) 
            : base(id)
        {
            _filePath = fileInfo.FullName;
            ContentType = contentType;
        }

    }
}