namespace TetraPak.AspNet.Diagnostics
{
    public interface ITetraPakDiagnosticsProvider
    {
        void DiagnosticsStartTimer(string timerKey);

        void DiagnosticsEndTimer(string timerKey);
    }
}