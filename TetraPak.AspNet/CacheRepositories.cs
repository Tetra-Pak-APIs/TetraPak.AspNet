namespace TetraPak.AspNet
{
    public static class CacheRepositories
    {
        public const string ClaimsPrincipals = "ClaimsPrincipals";
        
        public static class Tokens
        {
            public const string Identity = "IdTokens";
            public const string TokenExchange = "TxTokens";
            public const string ClientCredentials = "CcTokens";
            public const string DevProxy = "DpTokens";
        }
    }
}