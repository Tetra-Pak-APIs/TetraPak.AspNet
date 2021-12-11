using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Diagnostics;

#nullable enable

namespace TetraPak.AspNet.diagnostics
{
    public static class ServiceDiagnosticsHelper
    {
        const string KeyDiagnostics = "_tp_diag";
        
        public static ServiceDiagnostics? BeginDiagnostics(this HttpContext self, ILogger? logger)
        {
            var level = self.Request.GetDiagnosticsLevel(logger);
            if (level == ServiceDiagnosticsLevel.None)
                return null;
            
            var diagnostics = new ServiceDiagnostics();
            self.SetValue(KeyDiagnostics, diagnostics);
            
            // todo support telemetry log levels 'Request' and 'Response'

            return diagnostics;
        }
        
        /// <summary>
        ///   Returns a <see cref="ServiceDiagnostics"/> object if available; otherwise <c>null</c>. 
        /// </summary>
        public static ServiceDiagnostics? GetDiagnostics(this HttpContext self)
        {
            return self.GetValue<ServiceDiagnostics>(KeyDiagnostics);
        }

        public static void StartDiagnosticsTime(this HttpContext self, string timeKey) 
            => self.GetDiagnostics()?.StartTimer(timeKey);
        
        public static long? StopDiagnosticsTime(this HttpContext self, string timeKey, bool stopTimer = true) 
            => self.GetDiagnostics()?.GetElapsedMs(timeKey, stopTimer);
        
        public static ServiceDiagnostics End(this ServiceDiagnostics? self)
        {
            if (self is null)
                return null!;

            self.StopTimer();
            return self;
        }

    }
}