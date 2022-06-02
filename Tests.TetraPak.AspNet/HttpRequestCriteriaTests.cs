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
            ScriptComparisonExpression criteria = "query[phrase]==world";
            Assert.Equal(HttpRequestElement.Query, criteria.Element);
            Assert.Equal(ScriptComparisonOperator.IsEqual, criteria.Operator);
            Assert.Equal("phrase", criteria.Key);
            Assert.Equal("world", criteria.Value);
            
            criteria = "query[phrase]!=world";
            Assert.Equal(HttpRequestElement.Query, criteria.Element);
            Assert.Equal(ScriptComparisonOperator.NotEqual, criteria.Operator);
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
            
            Assert.False(request.IsMatch("unknown[phrase] == world"));     // unrecognized element
            Assert.False(request.IsMatch("query [ say ] == world"));       // unmatched key
            Assert.False(request.IsMatch("query[phrase] == unmatched"));   // unmatched value
        }
        
        [Fact]
        public void TestHeadersMatch()
        {
            const StringComparison IgnoreCase = StringComparison.InvariantCultureIgnoreCase;
            var headers = new Dictionary<string, string> { ["X-test"] = "Hello Cruel World" };
            var request = makeRequest("https://test.nu/hello", headers);
            Assert.True(request.IsMatch("headers[X-test] == Hello Cruel World"));
            Assert.True(request.IsMatch("headers[X-test] != Unmatched"));

            // test case sensitivity (element and key is always case-insensitive)
            Assert.True(request.IsMatch("HEADERS[X-test] == Hello Cruel World"));
            Assert.True(request.IsMatch("headers[X-TEST] == Hello Cruel World"));
            Assert.False(request.IsMatch("headers[X-test] == Hello Sweet World"));  // unmatched value
            Assert.True(request.IsMatch("headers[X-test] == HELLO CRUEL WORLD", IgnoreCase));
            
            Assert.False(request.IsMatch("unknown[phrase] == hello cruel world"));  // unrecognized element
            Assert.False(request.IsMatch("headers [ say ] == hello cruel world"));  // unmatched key
            Assert.False(request.IsMatch("headers[X-test] == unmatched"));          // unmatched value
        }

        [Fact]
        public void TestContainsMatch()
        {
            const StringComparison IgnoreCase = StringComparison.InvariantCultureIgnoreCase;
            var headers = new Dictionary<string, string> { ["X-test"] = "Hello Cruel World" };
            var request = makeRequest("https://test.nu/api/hello", headers);
            Assert.True(request.IsMatch("headers[X-test] ~~ Cruel", IgnoreCase));
            Assert.True(request.IsMatch("headers[X-test] !~ Sweet", IgnoreCase));
            Assert.True(request.IsMatch("url ~~ /api/", IgnoreCase));
            Assert.False(request.IsMatch("url !~ /api/", IgnoreCase));
            Assert.True(request.IsMatch("url ~~ /api/ && headers[X-test] ~~ World", IgnoreCase));
            Assert.False(request.IsMatch("url ~~ /api/ && headers[X-test] !~ World", IgnoreCase));
        }

        [Fact]
        public void TestLogicalExpressions()
        {
            const StringComparison IgnoreCase = StringComparison.InvariantCultureIgnoreCase;
            var headers = new Dictionary<string, string> { ["X-test"] = "Hello", ["Y-test"] = "World" };
            var request = makeRequest("https://test.nu/hello?say=Hello&scope=World", headers);
            var criteria = "headers[X-test] == Hello && headers[Y-test] == World || query[say] == Hello && query[scope] == World";
            Assert.True(request.IsMatch(criteria, IgnoreCase));
            criteria = "headers[X-test] == Hi && headers[Y-test] == World || query[say] == Hi && query[scope] == World";
            Assert.False(request.IsMatch(criteria, IgnoreCase));

            criteria = "!(headers[X-test] == Hi && headers[Y-test] == World) && query[scope] == World";
            Assert.True(request.IsMatch(criteria, IgnoreCase));
            criteria = "query[scope] == World && !(headers[X-test] == Hi && headers[Y-test] == World)";
            Assert.True(request.IsMatch(criteria, IgnoreCase));
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
                    Host = new HostString(uri.Host),
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