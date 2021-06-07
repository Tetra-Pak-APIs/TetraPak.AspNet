using System;
using System.Text;
using System.Threading.Tasks;
using TetraPak.CLI;

#pragma warning disable 1998

namespace TetraPak.Tools
{
    class Program
    {
        static readonly CliCommand[] s_commands = {
            new AlignNugetVersionCommand()
        };
        
        static async Task Main(string[] args)
        {
            var findCommandOutcome = await findCommandAsync(args);
            if (!findCommandOutcome)
            {
                exitWithOutcome(buildHelp());
                return;
            }

            var command = findCommandOutcome.Value;
            var outcome = await command.ExecuteAsync();
            if (!outcome)
            {
                exitWithOutcome(outcome);
            }
        }

        static async Task<Outcome<CliCommand>> findCommandAsync(string[] args)
        {
            foreach (var command in s_commands)
            {
                var outcome = await command.IsMatchAsync(args);
                if (outcome)
                    return outcome;
            }
            return Outcome<CliCommand>.Fail(new ArgumentException($"No recognized command: {args.ConcatCollection(" ")}"));
        }

        static Outcome<Program> buildHelp()
        {
            var sb = new StringBuilder();
            foreach (var command in s_commands)
            {
                sb.Append(command.GetHelp());
            }
            return Outcome<Program>.Fail(new Exception(sb.ToString()));
        }

        static void output(string text)
        {
            Console.WriteLine(text);
        }

        static void exitWithOutcome(Outcome outcome)
        {
            output(outcome.Exception.Message);
            Environment.Exit(-1);
        }
    }
}