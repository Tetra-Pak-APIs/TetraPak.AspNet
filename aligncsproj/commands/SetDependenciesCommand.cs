using System.Threading.Tasks;
using TetraPak.CLI;

namespace TetraPak.Tools
{
    public class SetDependenciesCommand : CliCommand
    {
        public override string CommandIdentifier { get; }
        public override string CommandDescription { get; }
        public override Task<Outcome<CliCommand>> ExecuteAsync()
        {
            throw new System.NotImplementedException();
        }

        protected override CommandFlag[] OnGetCommandFlags()
        {
            throw new System.NotImplementedException();
        }
    }
}