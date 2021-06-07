using System;
using System.Text;
using System.Threading.Tasks;

namespace TetraPak.CLI
{
    public abstract class CliCommand
    {
        protected CommandLineArgs CommandLineArgs { get; private set; }
        
        protected CommandFlag[] CommandFlags { get; private set; }
        
        public abstract string CommandIdentifier { get; }
        
        public abstract string CommandDescription { get; }

        public virtual Task<Outcome<CliCommand>> IsMatchAsync(string[] args)
        {
            CommandLineArgs = new CommandLineArgs(args);
            return args.Length >= 1 && args[0].Equals(CommandIdentifier, StringComparison.InvariantCultureIgnoreCase)
                ? Task.FromResult(Outcome<CliCommand>.Success(this))
                : Task.FromResult(Outcome<CliCommand>.Fail(new ArgumentOutOfRangeException($"Missing command: {CommandIdentifier}")));
        }
        
        protected virtual bool HasFlag(CommandFlag commandFlag)
        {
            var folderOutcome = CommandLineArgs.Get(commandFlag.Flags);
            return folderOutcome;
        }

        public abstract Task<Outcome<CliCommand>> ExecuteAsync();

        public virtual string GetHelp()
        {
            var sb = new StringBuilder();
            sb.Append(CommandIdentifier);
            sb.Append("\t\t");
            sb.AppendLine(CommandDescription);
            const char indent = '\t';
            foreach (var commandFlag in CommandFlags)
            {
                sb.Append(indent);
                if (commandFlag.IsFlagsOptional)
                {
                    sb.Append('[');
                }
                for (var i = 0; i < commandFlag.Flags.Length; i++)
                {
                    var flag = commandFlag.Flags[i];
                    sb.Append(flag);
                    if (i == commandFlag.Flags.Length - 1)
                        break;

                    sb.Append(" | ");
                }

                if (!string.IsNullOrWhiteSpace(commandFlag.Value))
                {
                    sb.Append(' ');
                    
                    if (commandFlag.IsValueOptional)
                    {
                        sb.Append('[');
                    }

                    sb.Append(commandFlag.Value);

                    if (commandFlag.IsValueOptional)
                    {
                        sb.Append(']');
                    }
                }
                if (commandFlag.IsFlagsOptional)
                {
                    sb.Append(']');
                }

                sb.Append("  // ");
                sb.AppendLine(commandFlag.Description);
            }

            return sb.ToString();
        }
        
        protected abstract CommandFlag[] OnGetCommandFlags();

        public CliCommand()
        {
            initialize();
        }

        void initialize()
        {
            CommandFlags = OnGetCommandFlags();
        }

        public class CommandFlag
        {
            public string[] Flags { get; }

            public string Value { get; private set; }

            public bool IsFlagsOptional { get; }
            
            public bool IsValueOptional { get; private set; }

            public string Description { get; }

            public CommandFlag WithValue(string value)
            {
                Value = value;
                return this;
            }

            public CommandFlag WithOptionalValue(string value)
            {
                Value = value;
                IsValueOptional = true;
                return this;
            }

            public CommandFlag(string[] flags, string description, bool isFlagsOptional = false)
            {
                Flags = flags;
                Description = description;
                IsFlagsOptional = isFlagsOptional;
            }
        }
    }
    
    
}