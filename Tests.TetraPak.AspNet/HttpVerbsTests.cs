using System;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using TetraPak.AspNet;
using Xunit;

namespace Tests.TetraPak.AspNet
{
    public class HttpVerbsTests
    {
        [Fact]
        public void DefaultToVerbs()
        {
            var httpMethods = new[] { HttpMethod.Connect, HttpMethod.Custom }; 
            
            var verbs = httpMethods.DefaultToVerbs(HttpVerbs.Get);
            Assert.Equal(2, verbs.Length);
            Assert.Equal(HttpVerbs.Connect, verbs[0]);
            Assert.Equal(HttpVerbs.Custom, verbs[1]);

            verbs = Array.Empty<HttpMethod>().DefaultToVerbs(HttpVerbs.Get);
            Assert.Single(verbs);
            Assert.Equal(HttpVerbs.Get, verbs[0]);
        }
        
        [Fact]
        public void DefaultToVerbs_withInvalidDefaultVerbs()
        {
            var noHttpMethods = Array.Empty<HttpMethod>();
            var twoHttpMethods = new[] { HttpMethod.Connect, HttpMethod.Custom };
            
            Assert.Throws<ArgumentOutOfRangeException>(() => noHttpMethods.DefaultToVerbs(HttpVerbs.Get, "Unknown"));
            Assert.Throws<ArgumentNullException>(() => twoHttpMethods.DefaultToVerbs());
        }

    }
}