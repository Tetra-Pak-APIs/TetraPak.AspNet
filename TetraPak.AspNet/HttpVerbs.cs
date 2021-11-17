using System.Linq;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace TetraPak.AspNet
{
    public static class HttpVerbs
    {
        public const string Connect = "CONNECT";
        public const string Custom = "CUSTOM";
        public const string Delete = "DELETE";
        public const string Get = "GET";
        public const string Head = "HEAD";
        public const string Options = "OPTIONS";
        public const string Patch = "PATCH";
        public const string Post = "POST";
        public const string Put = "PUT";
        public const string Trace = "TRACE";

        public static string[] EnsureGet(this HttpMethod[] methods) => methods.Ensure(Get);

        public static string[] Ensure(this HttpMethod[] methods, params string[] ensured) 
            => methods.Any() ? methods.ToStringVerbs() : ensured;
    }
}