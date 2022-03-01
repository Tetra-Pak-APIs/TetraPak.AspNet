using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   A string compatible (criteria) expression for use with HTTP requests.
    /// </summary>
    public class ScriptComparisonExpression : ScriptExpression
    {
        static readonly Regex s_regex = new Regex(@"(?<element>[a-zA-Z]+)\s*(?<index>\[\s*(?<key>.+)\s*\]\s*)?(?<operator>[\=\~\!]+)\s*(?<value>.+)", 
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
        
        /// <summary>
        ///   Specifies recognized elements of a HTTP request, for use in comparison operations.
        /// </summary>
        public static class Elements
        {
            /// <summary>
            ///   Represents the request URL.
            /// </summary>
            public const string Url = "url";

            /// <summary>
            ///   Represents request headers collection.
            /// </summary>
            public const string Headers = "headers";
            
            /// <summary>
            ///   Represents request query.
            /// </summary>
            public const string Query = "query";
        }

        /// <summary>
        ///   Gets the element (<see cref="Elements.Headers"/> or <see cref="Elements.Query"/>)
        ///   references in the operation. 
        /// </summary>
        public HttpRequestElement Element { get; private set; }

        /// <summary>
        ///   Identifies an item from the specified <see cref="Element"/>,
        ///   to be used for comparison with <see cref="Value"/>. 
        /// </summary>
        public string? Key { get; private set; }

        /// <summary>
        ///   Gets the item's value (identified by <see cref="Key"/>) from a request.
        /// </summary>
        /// <param name="request">
        ///   The <see cref="HttpRequest"/>
        /// </param>
        /// <returns>
        ///   A <see cref="string"/> value if the item can be found in the specified <see cref="Element"/>;
        ///   otherwise <c>null</c>.
        /// </returns>
        public string? ItemValue(HttpRequest request) => request.GetItemValue(Element, Key!);

        /// <summary>
        ///   Specifies the comparative operator.
        /// </summary>
        /// <seealso cref="ScriptComparisonOperator"/>
        public ScriptComparisonOperator Operator { get; private set; }

        /// <summary>
        ///   Gets the value to be matched with the specified <see cref="Key"/>. 
        /// </summary>
        public string? Value { get; private set; }

        /// <summary>
        ///   Executes the  specified operation and returns a value indicating a match. 
        /// </summary>
        /// <param name="request">
        ///   The <see cref="HttpRequest"/> to be matched by the operation.
        /// </param>
        /// <param name="comparison">
        ///   (optional; default=<see cref="StringComparison.InvariantCulture"/>)<br/>
        ///   Specifies how to match the <see cref="Value"/> (<see cref="Element"/> and <see cref="Key"/>
        ///   are always case-insensitive.
        /// </param>
        /// <returns>
        ///   <c>true</c> if <see cref="ItemValue"/> matches <see cref="Value"/>;
        ///   otherwise <c>false</c>.
        /// </returns>
        public override bool IsMatch(HttpRequest request, StringComparison comparison = StringComparison.InvariantCulture)
        {
            var itemValue = ItemValue(request);
            return itemValue is not null && isMatch(itemValue, comparison);
        }

        internal override ScriptExpression Invert()
        {
            var op = Operator.Invert();
            var stringValue = $"{Element}[{Key}] {op.ToStringToken()} {Value}";
            return new ScriptComparisonExpression(stringValue);
        }

        /// <summary>
        ///   Overrides base method to resolve <see cref="Element"/>, <see cref="Key"/> and <see cref="Value"/>.
        /// </summary>
        /// <param name="stringValue"></param>
        /// <returns>
        ///   The <paramref name="stringValue"/> if parsing is successful; otherwise <c>null</c>.
        /// </returns>
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
                Elements.Url => HttpRequestElement.Url,
                Elements.Headers => HttpRequestElement.Headers,
                Elements.Query => HttpRequestElement.Query,
                _ => HttpRequestElement.None
            };

            if (element == HttpRequestElement.None)
                return null;

            var opToken = match.Groups["operator"].Value switch
            {
                ScriptOperators.IsEqual => ScriptComparisonOperator.IsEqual,
                ScriptOperators.IsNotEqual => ScriptComparisonOperator.NotEqual,
                ScriptOperators.Contains => ScriptComparisonOperator.Contains,
                ScriptOperators.NotContains => ScriptComparisonOperator.NotContains,
                _ => ScriptComparisonOperator.None
            };
            if (opToken is ScriptComparisonOperator.None)
                return null;
                
            Element = element;
            Operator = opToken;
            Key = match.Groups["key"].Value!;
            Value = match.Groups["value"].Value!;
            return stringValue;
        }

        bool isMatch(string value, StringComparison comparison)
        {
            return Operator switch
            {
                ScriptComparisonOperator.IsEqual => value.Equals(Value, comparison),
                ScriptComparisonOperator.NotEqual => !value.Equals(Value, comparison),
                ScriptComparisonOperator.Contains => value.Contains(Value!, comparison),
                ScriptComparisonOperator.NotContains => !value.Contains(Value!, comparison),
                _ => false
            };
        }

        /// <summary>
        ///   Implicit type cast operation <see cref="string"/> => <see cref="ScriptComparisonExpression"/>. 
        /// </summary>
        /// <param name="stringValue">
        ///   The textual representation of a <see cref="ScriptComparisonExpression"/> value.
        /// </param>
        /// <returns></returns>
        public static implicit operator ScriptComparisonExpression(string? stringValue) => new(stringValue);

        /// <summary>
        ///   Initializes the <see cref="ScriptComparisonExpression"/>. 
        /// </summary>
        /// <param name="value">
        ///   A textual representation of a <see cref="ScriptComparisonExpression"/> value.
        /// </param>
        public ScriptComparisonExpression(string? value)
        : base(value)
        {
        }
    }
}