using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF
{
    class FileManager
    {
        readonly List<string> _issues = new();

        public bool HasIssues => _issues.Any();
        
        public bool IsVerbose { get; set; }

        public bool IsCleaning { get; set; }

        public FileOperation Operation { get; set; }

        public string Source { get; set; }

        public string Target { get; set; }

        public string Pattern { get; set; }

        public Task ExecuteAsync()
        {
            switch (Operation)
            {
                case FileOperation.Copy:
                    return copyAsync();
                    
                case FileOperation.Move:
                    return moveAsync();
                    
                case FileOperation.Delete:
                    return deleteAsync();
                    
                case FileOperation.List:
                    return listAsync();
                    
                default:
                    return Task.CompletedTask;
            }
        }

        Task copyAsync()
        {
            throw new NotImplementedException();
        }

        Task moveAsync()
        {
            throw new NotImplementedException();
        }

        Task deleteAsync()
        {
            throw new NotImplementedException();
        }

        Task listAsync()
        {
            if (!isListValid())
                return Task.CompletedTask;

            var folder = new DirectoryInfo(Source);
            var files = folder.GetFiles(Pattern);
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }
            return Task.CompletedTask;
        }

        bool isListValid()
        {
            if (string.IsNullOrEmpty(Source))
            {
                addIssueExpectedSource();
                return false;
            }

            if (!Directory.Exists(Source)) 
                return true;
            
            addIssueSourceFolderDoesNotExist();
            return false;
        }

        void addIssueExpectedSource() => addIssue("Expected source");

        void addIssueSourceFolderDoesNotExist() => addIssue($"Source folder does not exist: {Source}");

        void addIssue(string issue)
        {
            _issues.Add(issue);
        }

        void dumpState()
        {
            var sb = new StringBuilder();
            var props = GetType().GetProperties();
            foreach (var prop in props)
            {
                sb.Append(prop.Name);
                sb.Append('=');
                sb.AppendLine(prop.GetValue(this)?.ToString());
            }
            
            Console.WriteLine(sb.ToString());
        }
    }

    public enum FileOperation
    {
        Copy,
        
        Move,
        
        Delete,
        
        List
    }
}