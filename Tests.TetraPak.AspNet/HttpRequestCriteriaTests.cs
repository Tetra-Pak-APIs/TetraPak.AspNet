using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using TetraPak.AspNet;
using Xunit;

#nullable enable

namespace Tests.TetraPak.AspNet
{
    public class HttpRequestCriteriaTests
    {
        [Fact]
        public void TestParsing()
        {
            HttpComparison criteria = "query[phrase]==world";
            Assert.Equal(HttpRequestElement.Query, criteria.Element);
            Assert.Equal(ComparisonOperation.IsEqual, criteria.Operation);
            Assert.Equal("phrase", criteria.Key);
            Assert.Equal("world", criteria.Value);
            
            criteria = "query[phrase]!=world";
            Assert.Equal(HttpRequestElement.Query, criteria.Element);
            Assert.Equal(ComparisonOperation.IsNotEqual, criteria.Operation);
            Assert.Equal("phrase", criteria.Key);
            Assert.Equal("world", criteria.Value);
        }
        
        [Fact]
        public void TestParameterMatch()
        {
            const StringComparison IgnoreCase = StringComparison.InvariantCultureIgnoreCase;
            var request = makeRequest("https://test.nu/hello?phrase=World");
            Assert.True(request.IsMatch("query[Phrase] == World"));
            Assert.True(request.IsMatch("query[Phrase] != Unmatched"));

            // test case sensitivity (element and key is always case-insensitive)
            Assert.True(request.IsMatch("QUERY[phrase] == World"));
            Assert.True(request.IsMatch("query[PHRASE] == World"));
            Assert.False(request.IsMatch("query[phrase] == world"));       // unmatched value
            Assert.True(request.IsMatch("query[PHRASE] == WORLD", IgnoreCase));
            
            Assert.False(request.IsMatch("unknown[phrase] == world"));          // unrecognized element
            Assert.False(request.IsMatch("query [ say ] == world"));       // unmatched key
            Assert.False(request.IsMatch("query[phrase] == unmatched"));   // unmatched value
        }
        
        [Fact]
        public void TestHeadersMatch()
        {
            const StringComparison IgnoreCase = StringComparison.InvariantCultureIgnoreCase;
            var headers = new Dictionary<string, string> { ["X-test"] = "World" };
            var request = makeRequest("https://test.nu/hello", headers);
            Assert.True(request.IsMatch("headers[X-test] == World"));
            Assert.True(request.IsMatch("headers[X-test] != Unmatched"));

            // test case sensitivity (element and key is always case-insensitive)
            Assert.True(request.IsMatch("HEADERS[X-test] == World"));
            Assert.True(request.IsMatch("headers[X-TEST] == World"));
            Assert.False(request.IsMatch("headers[X-test] == world"));          // unmatched value
            Assert.True(request.IsMatch("headers[X-test] == WORLD", IgnoreCase));
            
            Assert.False(request.IsMatch("unknown[phrase] == world"));          // unrecognized element
            Assert.False(request.IsMatch("headers [ say ] == world"));       // unmatched key
            Assert.False(request.IsMatch("headers[X-test] == unmatched"));   // unmatched value
        }

        static HttpRequest makeRequest(string url, Dictionary<string,string>? headers = null)
        {
            var uri = new Uri(url);
            var httpContext = new DefaultHttpContext
            {
                Request =
                {
                    Method = "GET",
                    Scheme = uri.Scheme,
                    Path = uri.AbsolutePath,
                    QueryString = new QueryString(uri.Query)
                }
            };
            var request = httpContext.Request;
            if (headers is null)
                return request;

            foreach (var (key, value) in headers)
            {
                request.Headers[key] = new StringValues(value);
            }

            return request;
        }
    }
}