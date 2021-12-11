namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Provides <see cref="string"/> constants representing various standardised API related request initiators.
    /// </summary>
    public static class ApiRequestInitiators
    {
        /// <summary>
        ///   The initiator is an SDK <see cref="SdkBackendService"/>.
        /// </summary>
        public static string SdkBackendService(IBackendService service) => $"{service.ServiceName} (backend service)";
    }
}