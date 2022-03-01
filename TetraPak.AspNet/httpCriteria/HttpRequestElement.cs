using Microsoft.AspNetCore.Http;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Used to express a HTTP request element.
    /// </summary>
    /// <seealso cref="ScriptComparisonExpression"/>
    public enum HttpRequestElement
    {
        /// <summary>
        ///   No element is specified.
        /// </summary>
        None,
        
        /// <summary>
        ///   Specifies the <see cref="HttpRequest"/> URL element.
        /// </summary>
        Url,
        
        /// <summary>
        ///   Specifies the <see cref="HttpRequest.Query"/> element.
        /// </summary>
        Query,
        
        /// <summary>
        ///   Specifies the <see cref="HttpRequest.Headers"/> element.
        /// </summary>
        Headers,
        
        /// <summary>
        ///   Specifies the <see cref="HttpRequest.Body"/> element.
        /// </summary>
        Body
    }
}