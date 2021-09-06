using System;
using System.Linq;

namespace TetraPak.CLI
{
    public class CliArguments
    {
        readonly string[] _args;

        public bool IsFlagged(params string[] key)
        {
            return _args.Any(i =>
                key.Any(k => k.Equals(i, StringComparison.InvariantCultureIgnoreCase)));
        }

        public string GetString(params string[] key)
        {
            var index = Array.FindIndex(_args, s => key.Any(k => k.Equals(s, StringComparison.InvariantCultureIgnoreCase)));
            if (index == -1)
                return default;

            return index < _args.Length - 1 
                ? _args[index + 1] 
                : default;
        }

        public bool? GetBool(string key)
        {
            var value = GetString(key);
            if (value is null)
                return null;

            if (bool.TryParse(key, out var boolValue))
                return boolValue;

            if (value.Equals("yes", StringComparison.InvariantCultureIgnoreCase))
                return true;

            if (value.Equals("1", StringComparison.InvariantCultureIgnoreCase))
                return true;

            if (value.Equals("no", StringComparison.InvariantCultureIgnoreCase))
                return false;

            if (value.Equals("0", StringComparison.InvariantCultureIgnoreCase))
                return false;

            return null;
        }

        public CliArguments(string[] args)
        {
            _args = args;
        }
    }
}