using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

#nullable enable

namespace TetraPak.AspNet
{
    /// <summary>
    ///   A string compatible (criteria) expression for use with  
    /// </summary>
    public class HttpCriteria : StringValueBase
    {
        public static class Elements
        {
            public const string Header = "headers";
            public const string Parameter = "parameters";
        }

        public static class Operators
        {
            public const string Equals = "==";

            public const string Differs = "!=";
        }

        static readonly Regex s_regex = new Regex(@"(?<element>[a-zA-Z]+)\s*\[\s*(?<key>.+)\s*\]\s*(?<operator>[\=\!]+)\s*(?<value>.+)", 
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

        public HttpRequestElements Element { get; private set; }

        public string? Key { get; private set; }

        public EqualityOperation Operation { get; private set; }

        public string? Value { get; private set; }

        public bool IsMatch(HttpRequest request, StringComparison comparison = StringComparison.InvariantCulture)
        {
            switch (Element)
            {
                case HttpRequestElements.None:
                    return false;

                case HttpRequestElements.Parameter:
                    return isParameterMatch(request, comparison);
                
                case HttpRequestElements.Header:
                    return resolveHeaderMatch(request, comparison);
                
                case HttpRequestElements.Body:
                    throw new NotSupportedException();
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected override string? OnParse(string? stringValue)
        {
            var input = stringValue?.Trim();
            if (string.IsNullOrEmpty(input))
                return null;

            var match = s_regex.Match(input);
            if (!match.Success)
                return null;

            var element = match.Groups["element"].Value.ToLowerInvariant() switch
            {
                Elements.Header => HttpRequestElements.Header,
                Elements.Parameter => HttpRequestElements.Parameter,
                _ => HttpRequestElements.None
            };

            if (element == HttpRequestElements.None)
                return null;

            var operation = match.Groups["operator"].Value switch
            {
                Operators.Equals => EqualityOperation.Equals,
                Operators.Differs => EqualityOperation.Differs,
                _ => EqualityOperation.None
            };
            if (operation is EqualityOperation.None)
                return null;
                
            Element = element;
            Operation = operation;
            Key = match.Groups["key"].Value!;
            Value = match.Groups["value"].Value!;
            return stringValue;
        }

        bool isParameterMatch(HttpRequest request, StringComparison comparison)
        {
            return request.Query.ContainsKey(Key) && isMatch(request.Query[Key].ToString(), comparison);
        }

        bool resolveHeaderMatch(HttpRequest request, StringComparison comparison)
        {
            return request.Headers.ContainsKey(Key!) && isMatch(request.Headers[Key].ToString(), comparison);
        }

        bool isMatch(string value, StringComparison comparison)
        {
            return Operation switch
            {
                EqualityOperation.Equals => value.Equals(Value, comparison),
                EqualityOperation.Differs => !value.Equals(Value, comparison),
                _ => false
            };
        }

        public static implicit operator HttpCriteria(string? stringValue) => new(stringValue);

        public HttpCriteria(string? value)
        : base(value)
        {
            
        }
    }
    
    public enum HttpRequestElements
    {
        None,
        
        Parameter,
        
        Header,
        
        Body
    }

    public enum EqualityOperation
    {
        None,
        
        Equals,
        
        Differs
    }
}