using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TetraPak.CLI;
using TetraPak.files;
using TetraPak.Xml;
#pragma warning disable 1998

namespace TetraPak.Tools
{
    public class AlignNugetVersionCommand : CliCommand
    {
        readonly CommandFlag _pathFlag = new CommandFlag(
            new [] {"-p", "--path"}, 
            "Path to a project root folder", 
            true)
            .WithOptionalValue("<folder path>");

        string _path;

        // ReSharper disable once StringLiteralTypo
        public override string CommandIdentifier => "alignversion";

        public override string CommandDescription => "Aligns the assembly version with the nuget package version";

        public override async Task<Outcome<CliCommand>> IsMatchAsync(string[] args)
        {
            var outcome = await base.IsMatchAsync(args);
            if (!outcome)
                return outcome;

            var pathOutcome = CommandLineArgs.Get(_pathFlag.Flags);
            if (pathOutcome)
            {
                _path = pathOutcome.Value;
                return Outcome<CliCommand>.Success(this);
            }

            _path = CommandLineArgs.Items.Length >= 2
                    ? CommandLineArgs.Items[1] 
                    : Environment.CurrentDirectory;
            return Outcome<CliCommand>.Success(this);
        }

        public override async Task<Outcome<CliCommand>> ExecuteAsync()
        {
            var csprojOutcome = await resolveProjectFilePathAsync();
            if (!csprojOutcome)
                return Outcome<CliCommand>.Fail(csprojOutcome.Exception);

            var cancellationToken = new CancellationToken();
            var projectFilePath = csprojOutcome.Value;
            var loadOutcome = await XmlPatcher.LoadAsync(projectFilePath, cancellationToken);
            if (!loadOutcome)
                return Outcome<CliCommand>.Fail(loadOutcome.Exception);

            var patcher = loadOutcome.Value;
            var outcome = await patcher.CopyValue(
                "//PackageVersion",
                new[] { "//AssemblyVersion", "//FileVersion" },
                (_, e) =>
                {
                    e.Value = cleanForAssemblyVersion(e.Value);
                });
            if (!outcome)
                return Outcome<CliCommand>.Fail(outcome.Exception);

            var saveOutcome = await patcher.SaveAsync(cancellationToken);
            return saveOutcome
                ? Outcome<CliCommand>.Success(this)
                : Outcome<CliCommand>.Fail(saveOutcome.Exception);
        }
        
        async Task<Outcome<string>> resolveProjectFilePathAsync()
        {
            var resolveFolderOutcome = resolveFolder(_path);
            if (!resolveFolderOutcome)
                return Outcome<string>.Fail(resolveFolderOutcome.Exception);

            var root = resolveFolderOutcome.Value;
            var files = root.GetFiles("*.csproj");
            return files.Length switch
            {
                0 => Outcome<string>.Fail(new Exception($"No project files found in {_path}")),
                1 => Outcome<string>.Success(files.First().FullName),
                _ => guessProjectFilePathFromFolderName(root, files)
            };

            static Outcome<string> guessProjectFilePathFromFolderName(FileSystemInfo root, IEnumerable<FileInfo> files)
            {
                var dir = root.Name;
                var file = files.FirstOrDefault(i => i.Name.Equals(dir, StringComparison.CurrentCultureIgnoreCase));
                return file is { } 
                    ? Outcome<string>.Success(file.FullName) 
                    : Outcome<string>.Fail(new Exception($"Cannot resolve project file in folder {Environment.CurrentDirectory}"));
            }
        }

        static Outcome<DirectoryInfo> resolveFolder(string path)
        {
            var dir = !path.StartsWith(".")
                ? new DirectoryInfo(path)
                : new DirectoryInfo(Environment.CurrentDirectory).ResolveRelativeDirectory(path);
            
            return dir.Exists 
                ? Outcome<DirectoryInfo>.Success(dir) 
                : Outcome<DirectoryInfo>.Fail(new FileNotFoundException($"Folder not found: {path}"));
        }

        static string cleanForAssemblyVersion(string s)
        {
            var ca = s.ToCharArray();
            var sb = new StringBuilder();
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var i = 0; i < ca.Length; i++)
            {
                var c = ca[i];
                if (!char.IsNumber(c) && c != '.')
                    break;

                sb.Append(c);
            }

            return sb.ToString();
        }
        
        protected override CommandFlag[] OnGetCommandFlags() => new[] { _pathFlag };
    }
}