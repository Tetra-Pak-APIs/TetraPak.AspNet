using System;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;
using demo.Acme.Models;
using demo.Acme.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TetraPak;
using TetraPak.AspNet;
using TetraPak.files;

namespace demo.AcmeAssets.Data
{
    public class FilesRepository : Repository<FileModel>
    {
        protected override async Task<Outcome<FileModel>> OnMakeNewItemAsync(FileModel model)
        {
            var suffixOutcome = getFileSuffix(model);
            if (!suffixOutcome)
                return Outcome<FileModel>.Fail(suffixOutcome.Exception);

            // extremely unlikely, but resolve any name conflict by simply regenerating new file id ...
            var filePath = Path.Combine(RootFolder, $"{model.Id!}.{suffixOutcome.Value!}");
            while (File.Exists(filePath))
            {
                model = new FileModel(new RandomString(), model.File!);
                filePath = Path.Combine(RootFolder, model.Id!, suffixOutcome.Value!);
            }

            var fileInfoOutcome = ensureFolderAndGetFileInfo(filePath);
            if (!fileInfoOutcome)
                return Outcome<FileModel>.Fail(fileInfoOutcome.Exception);

            var fileInfo = fileInfoOutcome.Value!;
            await using (var stream = new FileStream(fileInfo.FullName, FileMode.Create))
            {
                await model.File!.CopyToAsync(stream);
            }
            
            return Outcome<FileModel>.Success(model);
        }

        public string RootFolder { get; }
        
        protected override Task OnUpdateItemAsync(FileModel target, FileModel source)
        {
            throw new System.NotImplementedException();
        }

        static Outcome<FileInfo> ensureFolderAndGetFileInfo(string path)
        {
            var fileInfo = new FileInfo(path);
            if (fileInfo.Directory is null)
                return Outcome<FileInfo>.Fail(new HttpServerConfigurationException("Invalid file path. No directory was configured"));
            
            if (!fileInfo.Directory!.Exists)
            {
                fileInfo.Directory.Create();
            }
            return Outcome<FileInfo>.Success(fileInfo);
        }

        public Task<Outcome<Stream>> ReadFileStream(FileModel model)
        {
            var fileName = model.File!.FileName;
            var path = Path.Combine(RootFolder, fileName);
            var fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
                return Task.FromResult(Outcome<Stream>.Fail(new FileNotFoundException($"File not found: {fileName}")));

            try
            {
                var stream = fileInfo.OpenRead();
                return Task.FromResult(Outcome<Stream>.Success(stream));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Outcome<Stream>.Fail(ex));
            }
        }

        static Outcome<string> getFileSuffix(FileModel model)
        {
            return model.ContentType switch
            {
                "application/png" => Outcome<string>.Success("png"),
                "image/png" => Outcome<string>.Success("png"),
                MediaTypeNames.Image.Jpeg => Outcome<string>.Success("jpg"),
                MediaTypeNames.Application.Zip => Outcome<string>.Success("zip"),
                _ => Outcome<string>.Fail(new NotSupportedException("Repository supports only PNG and JPEG files at this time"))
            };
        }

        public FilesRepository(ILogger<FilesRepository>? logger, IConfiguration configuration) 
        : base(logger)
        {
            RootFolder = configuration.GetValue<string>("FilesRoot") ?? "./files";
            new DirectoryInfo(RootFolder).DeleteAllWhereAsync(info => info.Name != "big-picture.jpg");
        }
    }
}