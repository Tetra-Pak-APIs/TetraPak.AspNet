using System;
using System.Threading.Tasks;
using TetraPak.CLI;

namespace MF
{
    class Program
    {
        static async Task Main(string[] arguments)
        {
            var args = new CliArguments(arguments);
            var fm = new FileManager
            {
                IsVerbose = args.IsFlagged("--verbose", "-v"),
                IsCleaning = args.IsFlagged("--clean", "-c"),
                Operation = getOperation(args),
                Pattern = args.GetString("--name", "-n") ?? "*.*",
                Source = args.GetString("--from", "-f") ?? Environment.CurrentDirectory,
                Target = args.GetString("--to", "-t")
            };
            await fm.ExecuteAsync();
        }

        static FileOperation getOperation(CliArguments args)
        {
            if (args.IsFlagged("--move", "-m"))
                return FileOperation.Move;
            
            if (args.IsFlagged("--copy", "-m"))
                return FileOperation.Copy;
            
            return args.IsFlagged("--delete", "-d")
                ? FileOperation.Delete 
                : FileOperation.List;
        }       
    }
}