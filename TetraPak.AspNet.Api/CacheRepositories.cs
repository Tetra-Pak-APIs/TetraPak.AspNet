namespace TetraPak.AspNet.Api
{
    public static class CacheRepositories
    {
        public static class Tokens
        {
            public const string Identity = "IdTokens";
            public const string TokenExchange = "TxTokens";
            public const string ClientCredentials = "CcTokens";
            public const string DevSidecar = "DsTokens";
        }
    }
}