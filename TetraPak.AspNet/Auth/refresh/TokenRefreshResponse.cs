namespace TetraPak.AspNet.Auth
{
    /// <summary>
    ///   Used to present the result from a token refresh flow response.
    /// </summary>
    public class TokenRefreshResponse
    {
        /// <summary>
        ///   Gets the new access token.
        /// </summary>
        public string AccessToken { get; set; }
        
        /// <summary>
        ///   Gets a new refresh token, if available.
        /// </summary>
        public string RefreshToken { get; set; }
        
        /// <summary>
        ///   Gets a provided identity token, if available.
        /// </summary>
        public string IdToken { get; set; }

        /// <summary>
        ///   Gets a value indicating the new access token's lifespan.
        /// </summary>
        public int? ExpiresInSeconds { get; set; }
    }
}