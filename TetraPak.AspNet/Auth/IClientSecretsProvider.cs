namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   Classes implementing this interface can be relied on to provide the app with a client id and client secret. 
    /// </summary>
    public interface IClientSecretsProvider
    {
        /// <summary>
        ///   Gets (confidential) client secrets (client id and, optionally, client secret).
        /// </summary>
        /// <param name="key">
        ///   (optional)<br/>
        ///   Specifies which (confidential) client secrets is requested.
        /// </param>
        /// <returns>
        ///   A <see cref="Credentials"/> value.
        /// </returns>
        Credentials GetClientSecrets(string key = null);
    }
}