namespace TetraPak.AspNet.Diagnostics
{
    public interface ITetraPakDiagnosticsProvider
    {
        void DiagnosticsStartTimer(string timerKey);

        long? DiagnosticsEndTimer(string timerKey);
    }
}