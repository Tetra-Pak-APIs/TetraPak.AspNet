namespace TetraPak.AspNet
{
    /// <summary>
    ///   Classes implementing this interface are able to obtain/enforce a message id
    ///   (used for tracking events related to a specific request/response roundtrip). 
    /// </summary>
    public interface IMessageIdProvider
    {
        /// <summary>
        ///   Retrieves a request message id if available. 
        /// </summary>
        /// <param name="enforce">
        ///   (optional; default=<c>false</c>)<br/>
        ///   When set a message id will be generated and injected into the request/response context.
        /// </param>
        /// <returns>
        ///   A <see cref="string"/> value if a message id was available (or enforced); otherwise <c>null</c>.
        /// </returns>
        string? GetMessageId(bool enforce = false);
    }
}