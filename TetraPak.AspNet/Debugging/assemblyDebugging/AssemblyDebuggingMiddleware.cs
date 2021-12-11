using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TetraPak.AspNet.Debugging
{
    class AssemblyDebuggingMiddleware
    {
        bool _isRunOnce;
        readonly bool _runOnce;
        readonly ILogger _logger;

        public async Task<bool> InvokeAsync()
        {
            if (_runOnce && _isRunOnce)
                return true;
            
            await _logger.DebugAssembliesInUseAsync();
            _isRunOnce = true;
            return true;
        }
        
        public AssemblyDebuggingMiddleware(bool runOnce, ILogger logger)
        {
            _runOnce = runOnce;
            _logger = logger;
        }
    }
}